using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using MyFitnessManager.Db.Entities;

namespace MyFitnessManager.Db.Repositories
{
    public class TrainingRepository : Repository<Training>, ITrainingRepository
    {
        public TrainingRepository(FitnessDbContext context) : base(context)
        {
            
        }

        public IEnumerable<Training> GetForRange(DateTime dateFrom, DateTime dateTo)
        {
            return DbSet.Where(t =>
                t.StartTime >= dateFrom && t.StartTime <= dateTo);
        }
    } 

    public interface ITrainingRepository : IRepository<Training>
    {
        IEnumerable<Training> GetForRange(DateTime dateFrom, DateTime dateTo);
    }
}
