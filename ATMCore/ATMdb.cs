using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ATMCore
{
    class ATMdb : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Transacciones> Transacciones { get; set; }
        public DbSet<Deposito> Deposito { get; set; }
        public DbSet<Retiro> Retiro { get; set; }
        public DbSet<Gerentes> Gerentes { get; set; }
        public DbSet<Operaciones> Operaciones { get; set; }
        public DbSet<Clientes> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Integrated Security=SSPI;" + "Persist Security Info=False;" +
                  "Initial Catalog = ATMdb;" + "Data Source = LAPTOP-NHT9K1JQ;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>()
                .Property(Usuarios => Usuarios.noCuenta)
                .IsRequired();
        }

    }

}
