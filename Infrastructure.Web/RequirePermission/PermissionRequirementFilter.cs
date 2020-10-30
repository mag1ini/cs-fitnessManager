using System.Linq;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Infrastructure.Web.RequirePermission
{
    public class PermissionRequirementFilter : IAuthorizationFilter
    {
        private readonly PermissionType _permissionType;
        private const string CLAIM_TYPE = "Permission";
        public PermissionRequirementFilter(PermissionType permissionType)
        {
            _permissionType = permissionType;
        }
        
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var hasPermission = context.HttpContext.User.Claims
                .Any(claim =>
                       claim.Type == CLAIM_TYPE
                    && claim.Value == ((int)_permissionType).ToString());

            if (!hasPermission) context.Result = new UnauthorizedResult();
        }
    }
}