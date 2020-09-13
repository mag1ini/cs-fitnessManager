using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFitnessManager.Db.Entities
{
    public class Coach : BaseEntity
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }    

        public TrainingType Speciality { get; set; }

        public IEnumerable<Training> Trainings { get; set; }
    }

}
