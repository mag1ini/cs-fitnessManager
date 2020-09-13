﻿using Microsoft.EntityFrameworkCore;
using MyFitnessManager.Db.Entities;

namespace MyFitnessManager.Db.Repositories
{
    public class CoachRepository : Repository<Coach>, ICoachRepository
    {
        public CoachRepository(FitnessDbContext context) : base(context)
        {
        }
    }

    public interface ICoachRepository : IRepository<Coach>
    {

    }
}