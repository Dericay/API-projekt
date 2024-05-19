using API_projekt.Data;
using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace API_projekt.Services
{
    public class AdminRepository : IAdmin
    {
        private AppDbContext _appDbContext;

        public AdminRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _appDbContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetSingelCustomer(int Id)
        {
            return await _appDbContext.Customers.FirstOrDefaultAsync(c => c.customerId == Id);
        }
        public async Task<IEnumerable<(string customerName, DateTime appointmentDate)>>BookingsForWeek(int customerId, int weekNumber, int year)
        {
            try
            {
                DateTime jan1 = new DateTime(year, 1, 1);
                int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;
                DateTime firstThursday = jan1.AddDays(daysOffset);
                int weekNum = (weekNumber == 1 && jan1.DayOfWeek >= DayOfWeek.Thursday) ? 1 : weekNumber;
                DateTime startDate = firstThursday.AddDays((weekNum - 1) * 7);
                DateTime endDate = startDate.AddDays(6);

                if (endDate.Year != year)
                {
                    endDate = endDate.AddDays(-7);
                }

                Console.WriteLine($"Calculated Start Date: {startDate}");
                Console.WriteLine($"Calculated End Date: {endDate}");

                var appointments = await _appDbContext.Appointments
                    .Include(a => a.customer)
                    .Where(a => a.customerId == customerId && a.StartTime >= startDate && a.EndTime <= endDate)
                    .Select(a => new
             {
                 CustomerName = $"{a.customer.FirstName} {a.customer.LastName}",
                 AppointmentDate = a.StartTime
             })
            .ToListAsync();


                var result = appointments.Select(a => (a.CustomerName, a.AppointmentDate)).ToList();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<(Customer customer, DateTime appointmentDate)>> AllCustomersCurrentWeek()
        {
            try
            {
                DateTime today = DateTime.Today;
                int currentDayOfWeek = (int)today.DayOfWeek;
                DateTime startOfWeek = today.AddDays(-currentDayOfWeek);
                DateTime endOfWeek = startOfWeek.AddDays(7).AddSeconds(-1);

                var appointments = await _appDbContext.Appointments
                    .Include(a => a.customer)
                    .Where(a => a.StartTime >= startOfWeek && a.EndTime <= endOfWeek)
                    .Select (a => new {a.customer, a.StartTime})
                    .ToListAsync();

                var customersWithAppointments = appointments
                    .Select(a => (a.customer, a.StartTime))
                    .Distinct()
                    .ToList();

                return customersWithAppointments;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
