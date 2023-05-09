using System.Threading.Tasks;

namespace CarSales.Services
{
    public interface IBookingManagement
    {
        public Task CreateBooking(int customerId, int carId);
    }
}
