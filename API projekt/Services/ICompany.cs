
using ClassLibrary.Models;

namespace API_projekt.Services
{
    public interface ICompany
    {
        Task<Appointment> AddAppointment(Appointment newAppointment);
        Task<Appointment> UpdateAppointment(Appointment upDate);
        Task<Appointment> DeleteAppointment(int appointmentId);
        Task<IEnumerable<Company>> Search(string name);
    }
}
