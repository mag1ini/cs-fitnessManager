using System;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Web.RequirePermission
{
    public class PermissionRequirementAttribute : TypeFilterAttribute
    {
        public PermissionRequirementAttribute(PermissionType permissionType)
        : base(typeof(PermissionRequirementFilter))
        {
            Arguments = new object[] {permissionType};
        }
    }
}