﻿// <auto-generated />
using System;
using Authentication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Authentication.Data.Migrations
{
    [DbContext(typeof(AuthenticationDbContext))]
    partial class AuthenticationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Authentication.Data.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("Refresh")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Authentication.Data.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Chief"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Manager"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Coach"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Client"
                        });
                });

            modelBuilder.Entity("Authentication.Data.Entities.RolePermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PermissionType")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("RoleId", "PermissionType")
                        .IsUnique();

                    b.ToTable("RolePermissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PermissionType = 2,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            PermissionType = 1,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 3,
                            PermissionType = 2,
                            RoleId = 2
                        },
                        new
                        {
                            Id = 4,
                            PermissionType = 2,
                            RoleId = 3
                        },
                        new
                        {
                            Id = 5,
                            PermissionType = 4,
                            RoleId = 3
                        },
                        new
                        {
                            Id = 6,
                            PermissionType = 6,
                            RoleId = 3
                        },
                        new
                        {
                            Id = 7,
                            PermissionType = 8,
                            RoleId = 3
                        },
                        new
                        {
                            Id = 8,
                            PermissionType = 10,
                            RoleId = 3
                        },
                        new
                        {
                            Id = 9,
                            PermissionType = 2,
                            RoleId = 4
                        },
                        new
                        {
                            Id = 10,
                            PermissionType = 4,
                            RoleId = 4
                        },
                        new
                        {
                            Id = 11,
                            PermissionType = 6,
                            RoleId = 4
                        },
                        new
                        {
                            Id = 12,
                            PermissionType = 8,
                            RoleId = 4
                        },
                        new
                        {
                            Id = 13,
                            PermissionType = 10,
                            RoleId = 4
                        },
                        new
                        {
                            Id = 14,
                            PermissionType = 5,
                            RoleId = 4
                        },
                        new
                        {
                            Id = 15,
                            PermissionType = 7,
                            RoleId = 4
                        },
                        new
                        {
                            Id = 16,
                            PermissionType = 9,
                            RoleId = 4
                        },
                        new
                        {
                            Id = 17,
                            PermissionType = 11,
                            RoleId = 4
                        },
                        new
                        {
                            Id = 18,
                            PermissionType = 12,
                            RoleId = 4
                        },
                        new
                        {
                            Id = 19,
                            PermissionType = 13,
                            RoleId = 4
                        });
                });

            modelBuilder.Entity("Authentication.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "12345679",
                            RoleId = 1,
                            Username = "alex"
                        },
                        new
                        {
                            Id = 2,
                            Password = "12345679",
                            RoleId = 2,
                            Username = "sam"
                        },
                        new
                        {
                            Id = 3,
                            Password = "12345679",
                            RoleId = 3,
                            Username = "david"
                        },
                        new
                        {
                            Id = 4,
                            Password = "12345679",
                            RoleId = 3,
                            Username = "miranda"
                        },
                        new
                        {
                            Id = 5,
                            Password = "12345679",
                            RoleId = 4,
                            Username = "piter"
                        },
                        new
                        {
                            Id = 6,
                            Password = "12345679",
                            RoleId = 4,
                            Username = "jack"
                        },
                        new
                        {
                            Id = 7,
                            Password = "12345679",
                            RoleId = 4,
                            Username = "oliver"
                        });
                });

            modelBuilder.Entity("Authentication.Data.Entities.RefreshToken", b =>
                {
                    b.HasOne("Authentication.Data.Entities.User", "User")
                        .WithOne("RefreshToken")
                        .HasForeignKey("Authentication.Data.Entities.RefreshToken", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Authentication.Data.Entities.RolePermission", b =>
                {
                    b.HasOne("Authentication.Data.Entities.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Authentication.Data.Entities.User", b =>
                {
                    b.HasOne("Authentication.Data.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
