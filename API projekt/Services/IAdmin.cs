using ClassLibrary.Models;

namespace API_projekt.Services
{
    public interface IAdmin
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetSingelCustomer(int Id);
        Task<IEnumerable<(string customerName, DateTime appointmentDate)>> BookingsForWeek(int customerId, int weekNumber, int year);
        Task<IEnumerable<(Customer customer, DateTime appointmentDate)>> AllCustomersCurrentWeek();
    }
}
