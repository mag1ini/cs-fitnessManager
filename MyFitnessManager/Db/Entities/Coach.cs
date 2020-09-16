using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFitnessManager.Db.Entities
{
    public class Coach : BaseEntity
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public TrainingType Speciality { get; set; }

        public IEnumerable<Training> Trainings { get; set; }
    }

}
