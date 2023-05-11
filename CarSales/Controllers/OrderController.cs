using System.Threading.Tasks;
using CarSales.Data;
using CarSales.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarSales.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrdersManagement _service;
        private readonly ICustomerService _customerService;
        private readonly ICarService _carService;
        private readonly AppDbContext _context;

        public OrderController(IOrdersManagement service, ICustomerService customerService, ICarService carService, AppDbContext context)
        {
            _carService = carService;
            _customerService = customerService;
            _service = service;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateOrder(int CarId)
        {
            var GetCar = await _context.Cars.FirstOrDefaultAsync(x => x.CarId == CarId);

            var CasIdLogged = (int)HttpContext.Session.GetInt32("CusId");

            //var user = await _carService.GetById(CarId);

            await _service.CreateNewOrder(CasIdLogged, GetCar.CarId, GetCar.Price);
            //Testing with Add view
            return RedirectToAction("Create", "Order");

        }

        public async Task<IActionResult> Create()

        {
            var CasIdLogged = (int)HttpContext.Session.GetInt32("CusId");

            var data = await _service.GetOrderByCustomerId(CasIdLogged);
            return View(data);
        }
    }
}
