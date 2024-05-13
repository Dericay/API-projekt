
using ClassLibrary.Models;

namespace API_projekt.Services
{
    public interface ICompany
    {
        Task<IEnumerable<Company>> GetAllCompanys();
        Task<Company> GetSingelCompany(int Id);
        Task<IEnumerable<Company>> Search(string name);
    }
}
