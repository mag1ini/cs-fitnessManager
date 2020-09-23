﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Authentication.API.Models;
using Authentication.Data;
using Authentication.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Authentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthenticationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration, AuthenticationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult> Authenticate([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _context.Users
                    .Include(u=>u.Role)
                    .ThenInclude(r=>r.Permissions)
                    .FirstOrDefaultAsync(u =>
                u.Username.Equals(model.Username,StringComparison.Ordinal)
             && u.Password.Equals(model.Password, StringComparison.Ordinal));

            if (user == null) return Unauthorized(ModelState);

            var accessToken = GenerateAccessToken(user);

            var refreshToken = Guid.NewGuid();
            
            _context.RefreshTokens.Update(new RefreshToken
            {
                //   Id = user.RefreshTokenId ?? 0,
                Id = user.RefreshTokenId ?? 0,
                Refresh = refreshToken,
                UserId = user.Id
            });
           await _context.SaveChangesAsync();

            return Ok(new TokenResponseModel(accessToken, refreshToken));

        }

        private string GenerateAccessToken(User user)
        {
            var permissions = user
                .Role
                .Permissions
                .Select(p =>
                    new Claim("Permission",  p.PermissionType.ToString()));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["Issuer"] ?? throw new ArgumentException(),
                Audience = _configuration["Audience"] ?? throw new ArgumentException(),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(_configuration.GetValue<int>("TokenExpiryDuration")),
                Subject = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.Username ),
                    new Claim(ClaimTypes.Role, user.Role.Name),
                    
                }.Concat(permissions)),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_configuration["JwtTokenSecret"])),
                SecurityAlgorithms.HmacSha256Signature )
            };

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.CreateJwtSecurityToken(tokenDescriptor);

            return handler.WriteToken(jwtToken);
        }
    }
}