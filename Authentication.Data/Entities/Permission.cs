using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Data;

namespace Authentication.Data.Entities
{
    public class Permission : BaseEntity
    {
        public PermissionType PermissionType { get; set; }
    }
}
