using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Data;

namespace Authentication.Data.Entities
{
    public class User : BaseEntity
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }

    
}
