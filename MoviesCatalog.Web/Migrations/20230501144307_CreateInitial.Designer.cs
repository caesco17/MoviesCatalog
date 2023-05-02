﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesCatalog.DataAccess.Data;

#nullable disable

namespace MoviesCatalog.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230501144307_CreateInitial")]
    partial class CreateInitial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MoviesCatalog.Core.Models.AccountRole", b =>
                {
                    b.Property<int>("AccountRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountRoleId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountRoleId");

                    b.ToTable("AccountRoles");

                    b.HasData(
                        new
                        {
                            AccountRoleId = 1,
                            Name = "User"
                        },
                        new
                        {
                            AccountRoleId = 2,
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("MoviesCatalog.Core.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"));

                    b.Property<int>("CreatedByAccountId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MovieCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Synapsis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieId");

                    b.HasIndex("CreatedByAccountId");

                    b.HasIndex("MovieCategoryId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            CreatedByAccountId = 2,
                            CreatedDate = new DateTime(2023, 5, 1, 8, 43, 7, 75, DateTimeKind.Local).AddTicks(1059),
                            MovieCategoryId = 1,
                            Name = "Goal!",
                            ReleaseYear = 2006,
                            Synapsis = "Pelicula de deportes."
                        },
                        new
                        {
                            MovieId = 2,
                            CreatedByAccountId = 2,
                            CreatedDate = new DateTime(2023, 5, 1, 8, 43, 7, 75, DateTimeKind.Local).AddTicks(1069),
                            MovieCategoryId = 2,
                            Name = "El padrino",
                            ReleaseYear = 1972,
                            Synapsis = "Pelicula de mafiosos."
                        },
                        new
                        {
                            MovieId = 3,
                            CreatedByAccountId = 1,
                            CreatedDate = new DateTime(2023, 5, 1, 8, 43, 7, 75, DateTimeKind.Local).AddTicks(1070),
                            MovieCategoryId = 3,
                            Name = "Iron Man",
                            ReleaseYear = 2008,
                            Synapsis = "Pelicula de ciencia ficcion."
                        },
                        new
                        {
                            MovieId = 4,
                            CreatedByAccountId = 1,
                            CreatedDate = new DateTime(2023, 5, 1, 8, 43, 7, 75, DateTimeKind.Local).AddTicks(1070),
                            MovieCategoryId = 4,
                            Name = "Parásitos",
                            ReleaseYear = 2019,
                            Synapsis = "Pelicula japonesa."
                        },
                        new
                        {
                            MovieId = 5,
                            CreatedByAccountId = 1,
                            CreatedDate = new DateTime(2023, 5, 1, 8, 43, 7, 75, DateTimeKind.Local).AddTicks(1071),
                            MovieCategoryId = 5,
                            Name = "Los Cazafantasmas",
                            ReleaseYear = 1984,
                            Synapsis = "Pelicula Clasica americana"
                        });
                });

            modelBuilder.Entity("MoviesCatalog.Core.Models.MovieCategory", b =>
                {
                    b.Property<int>("MovieCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieCategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieCategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            MovieCategoryId = 1,
                            Name = "Action"
                        },
                        new
                        {
                            MovieCategoryId = 2,
                            Name = "Comedy"
                        },
                        new
                        {
                            MovieCategoryId = 3,
                            Name = "Drama"
                        },
                        new
                        {
                            MovieCategoryId = 4,
                            Name = "Fantasy"
                        },
                        new
                        {
                            MovieCategoryId = 5,
                            Name = "Horror"
                        });
                });

            modelBuilder.Entity("MoviesCatalog.Core.Models.Ratings", b =>
                {
                    b.Property<int>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RatingId"));

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<int?>("RatedByAccountId")
                        .HasColumnType("int");

                    b.Property<int?>("RatedMovieMovieId")
                        .HasColumnType("int");

                    b.HasKey("RatingId");

                    b.HasIndex("RatedByAccountId");

                    b.HasIndex("RatedMovieMovieId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("MoviesCatalog.Core.Models.UserAccount", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<int>("AccountRoleId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.HasIndex("AccountRoleId");

                    b.ToTable("UserAccounts");

                    b.HasData(
                        new
                        {
                            AccountId = 1,
                            AccountRoleId = 1,
                            Email = "user@gmail.com",
                            Name = "User npc",
                            Password = "5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8"
                        },
                        new
                        {
                            AccountId = 2,
                            AccountRoleId = 2,
                            Email = "admin@gmail.com",
                            Name = "Admin npc",
                            Password = "5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8"
                        });
                });

            modelBuilder.Entity("MoviesCatalog.Core.Models.Movie", b =>
                {
                    b.HasOne("MoviesCatalog.Core.Models.UserAccount", "UserAccount")
                        .WithMany()
                        .HasForeignKey("CreatedByAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesCatalog.Core.Models.MovieCategory", "MovieCategory")
                        .WithMany()
                        .HasForeignKey("MovieCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MovieCategory");

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("MoviesCatalog.Core.Models.Ratings", b =>
                {
                    b.HasOne("MoviesCatalog.Core.Models.UserAccount", "RatedBy")
                        .WithMany()
                        .HasForeignKey("RatedByAccountId");

                    b.HasOne("MoviesCatalog.Core.Models.Movie", "RatedMovie")
                        .WithMany()
                        .HasForeignKey("RatedMovieMovieId");

                    b.Navigation("RatedBy");

                    b.Navigation("RatedMovie");
                });

            modelBuilder.Entity("MoviesCatalog.Core.Models.UserAccount", b =>
                {
                    b.HasOne("MoviesCatalog.Core.Models.AccountRole", "Roles")
                        .WithMany()
                        .HasForeignKey("AccountRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
