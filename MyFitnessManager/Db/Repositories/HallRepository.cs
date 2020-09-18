using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using MyFitnessManager.Db.Entities;

namespace MyFitnessManager.Db.Repositories
{
    public class HallRepository : Repository<Hall>, IHallRepository
    {
        public HallRepository(FitnessDbContext context) : base(context)
        {
        }
    }

    public interface IHallRepository : IRepository<Hall>
    {
    }
}