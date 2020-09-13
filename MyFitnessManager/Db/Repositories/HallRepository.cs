using Microsoft.EntityFrameworkCore;
using MyFitnessManager.Db.Entities;

namespace MyFitnessManager.Db.Repositories
{
    public class HallRepository : Repository<Hall>, IHallRepository
    {
        public HallRepository(DbContext context) : base(context)
        {
        }
    }

    public interface IHallRepository : IRepository<Hall>
    {
    }
}