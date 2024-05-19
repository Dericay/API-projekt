using API_projekt.Data;
using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace API_projekt.Services
{
    public class CustomerRepository : ICustomer
    {
        private AppDbContext _appDbContext;
        public CustomerRepository(AppDbContext appDbContext)
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
            if (result != null)
            {
                var auditRecord = new AppointmentAudit
                {
                    appointmentId = result.appointmentId,
                    Action = "Unboked",
                    OldValue = $"StartTime: {result.StartTime}, EndTime: {result.EndTime}",
                    NewValue = null,
                    Timestamp = DateTime.UtcNow,
                    customerId = result.customerId,
                    companyId = result.companyId,
                };

                await _appDbContext.AppointmentAudits.AddAsync(auditRecord);

                _appDbContext.Appointments.Remove(result);

                await _appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<Appointment> UpdateAppointment(int id, DateTime StartTime, DateTime EndTime)
        {
            var result = await _appDbContext.Appointments.FirstOrDefaultAsync(a => a.appointmentId == id);
            if (result != null)
            {
                var oldStartTime = result.StartTime;
                var oldEndTime = result.EndTime;

                result.StartTime = StartTime;
                result.EndTime = EndTime;

                var auditRecord = new AppointmentAudit
                {
                    appointmentId = result.appointmentId,
                    Action = "Update",
                    OldValue = $"StartTime: {oldStartTime}, EndTime: {oldEndTime}",
                    NewValue = $"StartTime: {StartTime}, EndTime: {StartTime}",
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
    }
}
