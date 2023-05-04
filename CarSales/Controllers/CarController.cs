using System.Linq;
using CarSales.Data;
using Microsoft.AspNetCore.Mvc;

namespace CarSales.Controllers
{
    public class CarController : Controller
    {
        private readonly AppDbContext _context;

        public CarController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var car = _context.Cars.ToList();
            return View(car);
        }
    }
}
