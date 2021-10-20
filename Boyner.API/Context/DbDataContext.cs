using Boyner.API.Configurations.Base;
using Boyner.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Boyner.API.Context
{
    public class DbDataContext : DbContext
    {
        public DbDataContext(DbContextOptions<DbDataContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes().Where(t => t.IsClass && typeof(BaseEntityConfiguration<>).IsAssignableFrom(t)));
            base.OnModelCreating(modelBuilder);
        }


    }
}
