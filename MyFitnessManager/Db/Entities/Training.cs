using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;

namespace MyFitnessManager.Db.Entities
{
    public class Training : BaseEntity
    {
        public string Title { get; set; }

        public TrainingType TrainingType { get; set; }

        public DateTime StartTime { get; set; }

        public int CoachId { get; set; }

        public Coach Coach { get; set; }

        public int HallId { get; set; }

        public Hall Hall { get; set; }
    }
}
