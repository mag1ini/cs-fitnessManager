using System;
using System.Linq;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Web.RequirePermission
{
    public class PermissionRequirementAttribute : TypeFilterAttribute
    {
        public PermissionRequirementAttribute(params PermissionType[] permissionType)
        : base(typeof(PermissionRequirementFilter))
        {
            Arguments = permissionType.Cast<object>().ToArray(); 
        }
    }
}