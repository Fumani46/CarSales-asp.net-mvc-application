using System.Collections.Generic;
using System.Threading.Tasks;
using CarSales.Models;

namespace CarSales.Services
{
    public interface IOrdersManagement
    {
        public Task<Order> GetOrderByCustomerIdAndCarId(int customerId, int carId);
        public Task<List<Order>> GetOrderByCustomerId(int customerId);

        public Task CreateNewOrder(int customerId, int carId, double carPrice);

        public Task UpdateOrder(int customerId, int carId, int quantity);

        public Task CompleteOrder(int customerId, int carId);
    }
}
