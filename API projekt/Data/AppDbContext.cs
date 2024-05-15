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
                customerId = 1,
                FirstName = "Anton",
                LastName = "Larsson",
                Address = "Solgatan 13",
                Phone = "021302145921",
                Email = "anton@gmail.com"
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                customerId = 2,
                FirstName = "Alfred",
                LastName = "Larsson",
                Address = "Mångatan 26",
                Phone = "0713021421",
                Email = "alfred@gmail.com"
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                customerId = 3,
                FirstName = "Anas",
                LastName = "Qlok",
                Address = "Storgatan 5",
                Phone = "07231249213",
                Email = "anas@qlok.com"
            });
            modelBuilder.Entity<Company>().HasData(new Company
            {
                companyId = 1,
                companyName = "Google",
                Adress = "Frigatan 2",
                Phone = "021312459",
                Email = "Google@gmail.com"
            });
            modelBuilder.Entity<Company>().HasData(new Company
            {
                companyId = 1,
                companyName = "Facebook",
                Adress = "Ängsgatan 4",
                Phone = "02131249124",
                Email = "facebook@hotmail.com"
            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {

            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {

            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {

            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {

            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {

            });

        }


    }
}
