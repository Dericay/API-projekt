using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace API_projekt.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 

        }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Company>  Companys { get; set; }
        public DbSet<Appointment> Appointments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(new Customer
            {

            });
        }
    }
}
