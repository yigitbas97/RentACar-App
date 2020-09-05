using Microsoft.EntityFrameworkCore;
using RentACar.Entities.ComplexType;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.DataAccess.Concrete
{
    public class RentACarContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RentACarDb;Integrated Security=True");
        }

        // Concrete
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }

        // Complex Types
        public DbSet<RentedCarsRecord> RentedCarsRecords { get; set; }
    }
}
