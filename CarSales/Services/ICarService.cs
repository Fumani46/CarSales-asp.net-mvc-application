using System.Collections.Generic;
using System.Threading.Tasks;
using CarSales.Models.Items;

namespace CarSales.Services
{
    public interface ICarService
    {
        public Task<List<Car>> GetAll();
        public Task AddCar(Car car);
        public Task<Car> GetById(int id);
    }
}
