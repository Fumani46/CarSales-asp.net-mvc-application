using CarSales.Models;
using CarSales.Models.Items;
using Microsoft.EntityFrameworkCore;

namespace CarSales.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(am => new
            {
                am.CusId
            });

            modelBuilder.Entity<Car>().HasKey(am => new
            {
                am.CarId
            });

            modelBuilder.Entity<Agent>().HasKey(am => new
            {
                am.EmpId
            });

            modelBuilder.Entity<Admin>().HasKey(am => new
            {
                am.EmpId
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Agent> Agents { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
