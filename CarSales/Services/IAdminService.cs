using System.Collections.Generic;
using System.Threading.Tasks;
using CarSales.Models;

namespace CarSales.Services
{
    public interface IAdminService
    {
        public Task<List<Admin>> GetAll();

        public Admin GetById(int id);

        public Task AddAdmin(Admin admin);

        public Task<Admin> GetUserByEmail(string email);
    }
}
