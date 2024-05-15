using ClassLibrary.Models;

namespace API_projekt.Services
{
    public interface ICustomer
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetSingelCustomer(int  id);
        Task<IEnumerable<Customer>> Search(string name);
        Task<Appointment> AddAppointment(int id,string firstname,string lastname, DateTime Start, DateTime End);
        Task<Appointment> Delete(int id);
        Task<Appointment> UpdateTime(int id, DateTime Start, DateTime End);
    }
}
