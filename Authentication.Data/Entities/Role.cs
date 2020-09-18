using System.Collections.Generic;
using Infrastructure.Data;

namespace Authentication.Data.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public List<Permission> Permissions { get; set; }
    }

    
}