using ClassLibrary.Models;

namespace API_projekt.Services
{
    public interface ICustomer
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetSingelCustomer(int  id);
        Task<IEnumerable<Customer>> Search(string name);
    }
}
