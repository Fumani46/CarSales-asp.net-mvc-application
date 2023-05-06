using System;
using System.Threading.Tasks;
using CarSales.Data;
using CarSales.Models.Items;
using CarSales.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace CarSales.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _service;
        private readonly AppDbContext _context;

        public CarController(ICarService service, AppDbContext context)
        {
            _service = service;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add([Bind("CarName,CarModel,Color,Year,Type,PictureUrl,Price")] Car car)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Error");
                return View(car);
            }

            IDbContextTransaction transaction = _context.Database.BeginTransaction();
            try
            {
                //var user = await _userManager.FindByEmailAsync(customer.Email);
                var user = await _service.GetById(car.CarId);
                if (user != null)
                {
                    ModelState.AddModelError(string.Empty, "This Car is already in use");
                    //TempData["Error"] = "This email address is already in use";
                    return View(car);
                }

                await _service.AddCar(car);
                transaction.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                ModelState.AddModelError(string.Empty, "Something went wrong :(");

                return View(car);
            }
        }
    }
}
