using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyFitnessManager.Db.Entities;

namespace MyFitnessManager.Db.Repositories
{
    public class TrainingRepository : Repository<Training>, ITrainingRepository
    {
        public TrainingRepository(DbContext context) : base(context)
        {
            
        }
    }

    public interface ITrainingRepository : IRepository<Training>
    {
        IEnumerable<Training> GetForRange(DateTime dateFrom, DateTime dateTo);
    }
}
