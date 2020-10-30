using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Infrastructure.Data;
using Infrastructure.Web.RequirePermission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFitnessManager.Db;
using MyFitnessManager.Db.Entities;
using MyFitnessManager.Db.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFitnessManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CoachController : ControllerBase
    {
        private readonly ICoachRepository _repository;


        public CoachController(ICoachRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<CoachController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coach>>> Get()
        {
            return Ok(await _repository.GetAsync());
        }

        // GET api/<CoachController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coach>> Get(int id)
        {
            return Ok(await _repository.GetAsync(id));
        }

        // POST api/<CoachController>
        [HttpPost]
        [PermissionRequirement(PermissionType.AddCoaches)]
        public async Task<ActionResult<Coach>> Post([FromBody] Coach coach)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _repository.Create(coach);

                await _repository.SaveChangesAsync();

                return Ok(coach);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<CoachController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Coach inCoach)
        {
            try
            {
                var toEdit = await _repository.GetAsync(id);
                if (toEdit==null) 
                    return BadRequest($"coach with {id} wasn't found");
           
                _repository.Update(inCoach);
                await _repository.SaveChangesAsync();

                return Ok(toEdit);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        // DELETE api/<CoachController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var toDelete = await _repository.GetAsync(id);

            if (toDelete == null)
                return BadRequest($"coach with {id} wasn't found");

            _repository.Delete(toDelete);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}
