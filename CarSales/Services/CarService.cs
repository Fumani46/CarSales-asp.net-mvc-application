using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSales.Data;
using CarSales.Models.Items;
using Microsoft.EntityFrameworkCore;

namespace CarSales.Services
{
    public class CarService : ICarService
    {
        private readonly AppDbContext _context;
        public CarService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

        }

        public async Task<List<Car>> GetAll()
        {
            var result = await _context.Cars.ToListAsync();
            return result;
        }

        async Task<Car> ICarService.GetById(int id)
        {
            var user = (await _context.Cars.ToListAsync()).FirstOrDefault(x => x.CarId == id);

            return user;
        }
    }
}
