using Microsoft.EntityFrameworkCore;
using MoviesCatalog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MoviesCatalog.DataAccess.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<MovieCategory> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Ratings> Ratings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
 

    }
}
