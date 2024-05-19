
using ClassLibrary.Models;

namespace API_projekt.Services
{
    public interface ICompany
    {
        Task<Appointment> AddAppointment(int custId, int compId, DateTime StartTime, DateTime EndTime);
        Task<Appointment> UpdateAppointment(Appointment upDate);
        Task<Appointment> DeleteAppointment(int appointmentId);
        Task<IEnumerable<CompanyAppointmentDTO>> Search(int id, DateTime StartTime, DateTime EndTime);
        Task<IEnumerable<CompanyAppointmentDTO>> GetFilteredSortedAppointments(int companyId, DateTime? startTime, DateTime? endTime, string sortBy, bool sortDescending);
    }
}
