using ClassLibrary;
using ClassLibrary.Models;

namespace API_projekt.Services
{
    public interface IAdmin
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<CustomerDTO> GetSingelCustomer(int Id);
        Task<IEnumerable<AppointmentDTO>> BookingsForWeek(int customerId, int weekNumber, int year);
        Task<IEnumerable<AppointmentDTO>> AllCustomersCurrentWeek();
        Task<IEnumerable<CustomerDTO>> GetFilteredSortedCustomers(string sortBy, bool sortDescending);
        Task<IEnumerable<AppointmentAuditDTO>> GetAllAppointmentAudits();
    }
}
