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
        public FitnessDbContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<Coach> Coaches { get; set; }

        public DbSet<Hall> Halls { get; set; }

      //  public DbSet<Training> Trainings { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coach>()
                .Property(p => p.Firstname)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Coach>()
                .Property(p => p.Lastname)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Coach>()
                .Property(p => p.Speciality)
                .HasConversion<int>();


        }

    }
}
