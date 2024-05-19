using API_projekt.Data;
using ClassLibrary;
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

        public async Task<CustomerDTO> GetSingelCustomer(int Id)
        {
            var customerAppointments = _appDbContext.Appointments
                .Where(x => x.customerId == Id)
                .Select(x => new CustomerAppointmentDTO
                {
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    CompanyName = x.company.companyName
                }).ToList();
            var customer = _appDbContext.Appointments
                .Include(x => x.customer)
                .Include(x => x.company)
                .Where(x => x.customerId == Id)
                .Select(x => new CustomerDTO
                {
                    Name = $"{x.customer.FirstName} {x.customer.LastName}",
                    Address = x.customer.Address,
                    Phone = x.customer.Phone,
                    Email = x.customer.Email,
                    Appointments = customerAppointments
                }).FirstOrDefault();

            return customer;
        }
        public async Task<IEnumerable<AppointmentDTO>>BookingsForWeek(int customerId, int weekNumber, int year)
        {
            try
            {
                DateTime jan1 = new DateTime(year, 1, 1);
                int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;
                DateTime firstThursday = jan1.AddDays(daysOffset);
                int weekNum = (weekNumber == 1 && jan1.DayOfWeek >= DayOfWeek.Thursday) ? 1 : weekNumber;
                DateTime startDate = firstThursday.AddDays((weekNum - 1) * 7);
                DateTime endDate = startDate.AddDays(6).Date.AddDays(1).AddTicks(-1);

                if (endDate.Year != year)
                {
                    endDate = endDate.AddDays(-7);
                }

                var appointments = await _appDbContext.Appointments
                    .Include(a => a.customer)
                    .Include(c => c.company)
                    .Where(a => a.customerId == customerId && a.StartTime >= startDate && a.EndTime <= endDate && a.companyId == a.company.companyId)
                    .Select(a => new AppointmentDTO
                    {
                        CustomerName = $"{a.customer.FirstName} {a.customer.LastName}",
                        StartTime = a.StartTime,
                        EndTime = a.EndTime,
                        CompanyName = a.company.companyName,
                    }).ToListAsync();


                return appointments;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<AppointmentDTO>> AllCustomersCurrentWeek()
        {
            try
            {
                DateTime today = DateTime.Today;
                int currentDayOfWeek = (int)today.DayOfWeek;
                DateTime startOfWeek = today.AddDays(-currentDayOfWeek);
                DateTime endOfWeek = startOfWeek.AddDays(7).AddSeconds(-1);

                    var appointments = await _appDbContext.Appointments
                    .Include(a => a.customer)
                    .Include(c => c.company)
                    .Where(a => a.StartTime >= startOfWeek && a.EndTime <= endOfWeek)
                    .Select(a => new AppointmentDTO
                    {
                        CustomerName = $"{a.customer.FirstName} {a.customer.LastName}",
                        StartTime = a.StartTime,
                        EndTime = a.EndTime,
                        CompanyName = a.company.companyName,
                    }).ToListAsync();


                return appointments;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<CustomerDTO>> GetFilteredSortedCustomers(string sortBy, bool sortDescending)
        {
            var query = _appDbContext.Customers.AsQueryable();

            query = sortBy switch
            {
                "Name" => sortDescending ? query.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName)
                : query.OrderBy(x => x.FirstName).ThenBy(x => x.LastName),
                "Email" => sortDescending ? query.OrderByDescending(x => x.Email)
                : query.OrderBy(x => x.Email),
                "Address" => sortDescending ? query.OrderByDescending(x => x.Address)
                : query.OrderBy(x => x.Address),
                _ => query
            };

            var customers = await query.Select(x => new CustomerDTO
            {
                Name = $"{x.FirstName} {x.LastName}",
                Address = x.Address,
                Phone = x.Phone,
                Email = x.Email
            }).ToListAsync();

            return customers;
        }

        public async Task<IEnumerable<AppointmentAuditDTO>> GetAllAppointmentAudits()
        {
            var auditRecords = await _appDbContext.AppointmentAudits.ToListAsync();
            var auditDTOs = auditRecords.Select(a => new AppointmentAuditDTO
            {
                AuditId = a.AuditId,
                AppointmentId = a.appointmentId,
                Action = a.Action,
                OldValue = a.OldValue,
                NewValue = a.NewValue,
                Timestamp = a.Timestamp,
                CustomerId = a.customerId,
                CompanyId = a.companyId
            }).ToList();

            return auditDTOs;
        }


    }
}
