using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MyFitnessManager.Db.Entities;

namespace MyFitnessManager.Models
{
    public class TrainingAddModel
    {
        [Required, MaxLength(255)]
        public string Title { get; set; }

        public TrainingType TrainingType { get; set; }

        public int CoachId { get; set; }

        public int HallId { get; set; }

        public DateTime StartTime { get; set; }
    }
}
