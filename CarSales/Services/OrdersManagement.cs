using System;
using System.Threading.Tasks;
using CarSales.Data;
using CarSales.Enums;
using CarSales.Models;
using Microsoft.EntityFrameworkCore;

namespace CarSales.Services
{
    public class OrdersManagement : IOrdersManagement
    {
        private readonly AppDbContext _context;
        private readonly ICarService _carService;
        public OrdersManagement(ICarService carService, AppDbContext dbContext)
        {
            _carService = carService;
            _context = dbContext;
        }

        public async Task<Order> GetOrderByCustomerIdAndCarId(int customerId, int carId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.CustomerId == customerId && x.CarId == carId);

            return order;
        }

        public async Task CreateNewOrder(int customerId, int carId, double carPrice)
        {
            var car = await _carService.GetById(carId);

            var newOrder = new Order
            {
                CarId = carId,
                CarName = car.CarName,
                CarModel = car.CarModel,
                CarPrice = car.Price,
                CustomerId = customerId,
                Quantity = 1,
                TotalAmount = carPrice,
                CreateDate = DateTime.Now,
                LastModified = DateTime.Now,
                Status = OrderStatus.InCart
            };

            _context.Add(newOrder);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrder(int customerId, int carId, int quantity)
        {
            var order = await GetOrderByCustomerIdAndCarId(customerId, carId);

            if (order != null)
            {
                var car = await _context.Cars.FirstOrDefaultAsync(x => x.CarId == carId);
                if (car != null)
                {
                    order.TotalAmount += car.Price;
                    order.Quantity += quantity;
                    order.LastModified = DateTime.Now;

                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
            }
        }

        /// <summary>
        /// Checkout order, update order status to complete 
        /// </summary>
        /// <param name="customerId">Customer for the order</param>
        /// <param name="carId">Car in the order</param>s
        /// <returns></returns>
        public async Task CompleteOrder(int customerId, int carId)
        {
            var order = await GetOrderByCustomerIdAndCarId(customerId, carId);
            if (order != null)
            {
                order.Status = OrderStatus.Complete;
            }
        }
    }
}
