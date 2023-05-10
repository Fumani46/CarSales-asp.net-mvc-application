using System.Threading.Tasks;
using CarSales.Models;

namespace CarSales.Services
{
    public interface IBookingManagement
    {
        public Task CreateBooking(int customerId, int carId);
        public Task<Booking> GetBookingByCustomerId(int customerId);
    }
}
