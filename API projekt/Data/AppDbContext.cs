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
                companyId = 2,
                companyName = "Facebook",
                Adress = "Ängsgatan 4",
                Phone = "02131249124",
                Email = "facebook@hotmail.com"
            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                appointmentId = 1,
                customerId = 1,
                StartTime = new DateTime(2024, 05, 21, 9, 15, 0),
                EndTime = new DateTime(2024, 05, 21, 10, 15, 0),
                companyId = 1,
            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                appointmentId = 2,
                customerId = 2,
                StartTime = new DateTime(2024, 05, 25, 11, 10, 0),
                EndTime = new DateTime(2024, 05, 25, 12, 10, 0),
                companyId = 1,
            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                appointmentId = 3,
                customerId = 3,
                StartTime = new DateTime(2024, 05, 30, 9, 0, 0),
                EndTime = new DateTime(2024, 05, 30, 10, 0, 0),
                companyId = 2,
            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                appointmentId = 4,
                customerId = 2,
                StartTime = new DateTime(2024, 06, 05, 13, 0, 0),
                EndTime = new DateTime(2024, 05, 21, 14, 0, 0),
                companyId = 2,
            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                appointmentId = 5,
                customerId = 1,
                StartTime = new DateTime(2024, 06, 15, 10, 30, 0),
                EndTime = new DateTime(2024, 06, 15, 12, 30, 0),
                companyId = 2,
            });

        }


    }
}
