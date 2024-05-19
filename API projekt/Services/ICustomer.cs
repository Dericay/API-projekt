using ClassLibrary.Models;

namespace API_projekt.Services
{
    public interface ICustomer
    {
        Task<Appointment> AddAppointment(int custId, int compId, DateTime StartTime, DateTime EndTime);
        Task<Appointment> UpdateAppointment(int id, DateTime StartTime, DateTime EndTime);
        Task<Appointment> DeleteAppointment(int appointmentId);
    }
}
