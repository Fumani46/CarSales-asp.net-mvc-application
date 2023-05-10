using System.Threading.Tasks;
using CarSales.Data;
using CarSales.Models;
using CarSales.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarSales.Controllers
{
    public class BookingController : Controller
    {

        private readonly UserManager<Customer> _userManager;
        private readonly SignInManager<Customer> _signInManager;
        private readonly IBookingManagement _service;
        private readonly AppDbContext _context;

        public BookingController(IBookingManagement service, AppDbContext context/*UserManager<Customer> userManager, SignInManager<Customer> signInManager, */)
        {
            // _userManager = userManager;
            //_signInManager = signInManager;
            _service = service;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateBooking(int CarId)
        {
            var GetCar = await _context.Cars.FirstOrDefaultAsync(x => x.CarId == CarId);

            var CasIdLogged = (int)HttpContext.Session.GetInt32("CusId");

            //var user = await _carService.GetById(CarId);

            _service.CreateBooking(CasIdLogged, GetCar.CarId);
            return RedirectToAction("ViewBooking", "Booking");

        }

        public async Task<IActionResult> GetOrder(int CusId)

        {
            var CasIdLogged = (int)HttpContext.Session.GetInt32("CusId");

            var data = await _service.GetBookingByCustomerId(CasIdLogged);
            return View(data);
        }

    }
}
