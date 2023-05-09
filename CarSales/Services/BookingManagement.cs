using System.Threading.Tasks;
using CarSales.Data;
using CarSales.Models;

namespace CarSales.Services
{
    public class BookingManagement : IBookingManagement
    {
        private readonly AppDbContext _context;
        private readonly ICarService _carService;
        public BookingManagement(ICarService carService, AppDbContext dbContext)
        {
            _carService = carService;
            _context = dbContext;
        }
        public async Task CreateBooking(int customerId, int carId)
        {
            var car = await _carService.GetById(carId);

            var newOrder = new Order
            {
                CarId = carId,
                CarName = car.CarName,
                CarModel = car.CarModel,
                CarPrice = car.Price,
                CustomerId = customerId,
            };

            _context.Add(newOrder);
            await _context.SaveChangesAsync();
        }
    }
}
