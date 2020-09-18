using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using MyFitnessManager.Db.Entities;

namespace MyFitnessManager.Db.Repositories
{

    public class CoachRepository : Repository<Coach>, ICoachRepository
    {
        public CoachRepository(FitnessDbContext context) : base(context)
        {
           
        }

        public override void Update(Coach entity)
        {
            var res =   this.Get(entity.Id);
            if (res != null)
            {
                res.Firstname = entity.Firstname;
                res.Lastname = entity.Lastname;
                res.Speciality = entity.Speciality;
            }

            base.Update(res);
        }
    }

    public interface ICoachRepository : IRepository<Coach>
    {

    }
}