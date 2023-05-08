using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSales.Data;
using CarSales.Models;
using Microsoft.EntityFrameworkCore;

namespace CarSales.Services
{
    public class AdminService : IAdminService
    {
        private readonly AppDbContext _context;
        public AdminService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAdmin(Admin admin)
        {
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Admin>> GetAll()
        {
            var result = await _context.Admins.ToListAsync();
            return result;
        }

        public Admin GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Admin> GetUserByEmail(string email)
        {
            var user = (await _context.Admins.ToListAsync()).FirstOrDefault(x => x.Email == email);

            return user;
        }
    }
}
