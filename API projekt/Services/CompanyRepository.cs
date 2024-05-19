using API_projekt.Data;
using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace API_projekt.Services
{
    public class CompanyRepository : ICompany
    {
        private AppDbContext _appDbContext;

        public CompanyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Appointment> AddAppointment(int custId, int compId, DateTime StartTime, DateTime EndTime)
        {
            var newAppointment = new Appointment
            {
                customerId = custId,
                companyId = compId,
                StartTime = StartTime,
                EndTime = EndTime
            };

            var result = await _appDbContext.Appointments.AddAsync(newAppointment);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }


        public async Task<Appointment> DeleteAppointment(int appointmentId)
        {
            var result = await _appDbContext.Appointments.FirstOrDefaultAsync(a => a.appointmentId == appointmentId);
            if(result != null)
            {
                _appDbContext.Appointments.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<CompanyAppointmentDTO>> Search(int id, DateTime StartTime, DateTime EndTime)
        {
            var appointments = await _appDbContext.Appointments
                .Include(x => x.customer)
                .Where(x => x.companyId == id && x.StartTime >= StartTime && x.EndTime <= EndTime)
                .Select(x => new CompanyAppointmentDTO
                {
                    CustomerName = $"{x.customer.FirstName} {x.customer.LastName}",
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,

                }).ToListAsync();

            return appointments;
        }

        public async Task<Appointment> UpdateAppointment(Appointment upDate)
        {
            var result = await _appDbContext.Appointments.FirstOrDefaultAsync(a => a.appointmentId == upDate.appointmentId);
            if (result != null)
            {
                var oldStartTime = result.StartTime;
                var oldEndTime = result.EndTime;

                result.StartTime = upDate.StartTime;
                result.EndTime = upDate.EndTime;

                var auditRecord = new AppointmentAudit
                {
                    appointmentId = result.appointmentId,
                    Action = "Update",
                    OldValue = $"StartTime: {oldStartTime}, EndTime: {oldEndTime}",
                    NewValue = $"StartTime: {upDate.StartTime}, EndTime: {upDate.StartTime}",
                    Timestamp = DateTime.UtcNow,
                    customerId = result.customerId,
                    companyId = result.companyId,
                };

                await _appDbContext.AppointmentAudits.AddAsync(auditRecord);

                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<IEnumerable<CompanyAppointmentDTO>> GetFilteredSortedAppointments(int companyId, DateTime? startTime, DateTime? endTime, string sortBy, bool sortDescending)
        {
            var query = _appDbContext.Appointments
                .Include(x => x.customer)
                .Where(x => x.companyId == companyId)
                .AsQueryable();

            
            if (startTime.HasValue)
            {
                query = query.Where(x => x.StartTime >= startTime.Value);
            }
            if (endTime.HasValue)
            {
                query = query.Where(x => x.EndTime <= endTime.Value);
            }

            query = sortBy switch
            {
                "CustomerName" => sortDescending ? query.OrderByDescending(x => x.customer.FirstName).ThenByDescending(x => x.customer.LastName)
                : query.OrderBy(x => x.customer.FirstName).ThenBy(x => x.customer.LastName),
                "StartTime" => sortDescending ? query.OrderByDescending(x => x.StartTime)
                : query.OrderBy(x => x.StartTime),
                "EndTime" => sortDescending ? query.OrderByDescending(x => x.EndTime)
                : query.OrderBy(x => x.EndTime),
                _ => query
            };

            var appointments = await query
                .Select(x => new CompanyAppointmentDTO
                {
                    CustomerName = $"{x.customer.FirstName} {x.customer.LastName}",
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                }).ToListAsync();

            return appointments;
        }

    }
}
