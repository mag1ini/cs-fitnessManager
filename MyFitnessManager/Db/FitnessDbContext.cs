using Microsoft.EntityFrameworkCore;
using MyFitnessManager.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFitnessManager.Db
{
    public class FitnessDbContext : DbContext
    {
        public DbSet<Coach> Coaches { get; set; }

        public DbSet<Hall> Halls { get; set; }

        public DbSet<Training> Trainings { get; set; }
    }
}
