using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ConsoleCoreProject
{
    class Northwind : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Integrated Security=SSPI;"+"Persist Security Info=False;" +
                  "Initial Catalog = Northwind;" + "Data Source = LAPTOP-NHT9K1JQ;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(Category => Category.CategoryName)
                .IsRequired()
                .HasMaxLength(40);
        }

    }
    
}
