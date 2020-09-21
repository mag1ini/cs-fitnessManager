using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Data
{
    public class AuthenticationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public AuthenticationDbContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasData(new Role[]
                {
                    // Client
                    new Role
                    {
                        Id = 1, Name = "Client", Permissions = new List<Permission>
                        {
                            Permission.EditOwnProfile,
                            Permission.AssignTrainingToSelf,
                        }
                    },
                    // Coach
                    new Role
                    {
                        Id = 1, Name = "Coach", Permissions = new List<Permission>
                        {
                            Permission.EditOwnProfile,
                        }
                    },
                    // Manager
                    new Role
                    {
                        Id = 1, Name = "Manager", Permissions = new List<Permission>
                        {
                            Permission.EditOwnProfile,

                            Permission.AddClients,
                            Permission.AddCoaches,
                            Permission.AddHalls,
                            Permission.AddTrainings,
                        }
                    },
                    // Chief
                    new Role
                    {
                        Id = 1, Name = "Chief", Permissions = new List<Permission>
                        {
                            Permission.EditOwnProfile,

                            Permission.AddCoaches,
                            Permission.ManageCoaches,

                            Permission.AddClients,
                            Permission.ManageClients,

                            Permission.AddHalls,
                            Permission.ManageHalls,

                            Permission.AddTrainings,
                            Permission.ManageTrainings,

                            Permission.AddManagers,
                            Permission.ManageManagers,
                        }
                    },
                });

            modelBuilder.Entity<User>()
                .HasData(new[]
                {
                    new User {Id = 1, RoleId = 1},
                    new User {Id = 2, RoleId = 1},
                    new User {Id = 3, RoleId = 1},

                    new User {Id = 4, RoleId = 2},

                    new User {Id = 5, RoleId = 3},

                    new User {Id = 6, RoleId = 4},
                });
        }
    }
}
