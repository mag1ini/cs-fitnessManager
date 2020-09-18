using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;

namespace MyFitnessManager.Db.Entities
{
    public class Hall : BaseEntity
    {
        public string Title { get; set; }

        public int Capacity { get; set; }
        
        public IEnumerable<Training> Trainings { get; set; }
    }
}
