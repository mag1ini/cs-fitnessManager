using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Data;

namespace Authentication.Data.Entities
{
    public class Permission : BaseEntity
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public PermissionType PermissionType { get; set; }

        public static explicit operator int(Permission v)
        {
            throw new NotImplementedException();
        }
    }
}
