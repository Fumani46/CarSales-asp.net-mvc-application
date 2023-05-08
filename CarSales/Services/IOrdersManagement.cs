using CarSales.Models;
using System.Threading.Tasks;

namespace CarSales.Services
{
    public interface IOrdersManagement
    {
        public Task<Order> GetOrderByCustomerIdAndCarId(int customerId, int carId);

        public Task CreateNewOrder(int customerId, int carId, double carPrice);

        public Task UpdateOrder(int customerId, int carId, int quantity);

        public Task CompleteOrder(int customerId, int carId);
    }
}
