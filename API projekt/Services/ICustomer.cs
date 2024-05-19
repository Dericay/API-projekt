using ClassLibrary.Models;

namespace API_projekt.Services
{
    public interface ICustomer
    {
        Task<Appointment> AddAppointment(Appointment newAppointment);
        Task<Appointment> UpdateAppointment(Appointment upDate);
        Task<Appointment> DeleteAppointment(int appointmentId);
    }
}
