using System;
using System.Linq;
using System.Threading.Tasks;
using CarSales.Data;
using CarSales.Models;
using CarSales.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace CarSales.Controllers
{
    public class AdminController : Controller
    {

        private readonly IAdminService _service;
        private readonly AppDbContext _context;

        public AdminController(IAdminService service, AppDbContext context/*UserManager<Customer> userManager, SignInManager<Customer> signInManager, */)
        {
            // _userManager = userManager;
            //_signInManager = signInManager;
            _service = service;
            _context = context;
        }

        //Get: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Admin admin)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Error");
                return View(admin);
            }

            IDbContextTransaction transaction = _context.Database.BeginTransaction();
            try
            {
                //var user = await _userManager.FindByEmailAsync(customer.Email);
                var user = await _service.GetUserByEmail(admin.Email);
                if (user != null)
                {
                    ModelState.AddModelError(string.Empty, "This email address is already in use");
                    //TempData["Error"] = "This email address is already in use";
                    return View(admin);
                }
                else if (admin.Password != admin.ConfirmPassword)
                {
                    ModelState.AddModelError(string.Empty, "Password does not match");
                    return View(admin);
                }

                await _service.AddAdmin(admin);
                transaction.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                ModelState.AddModelError(string.Empty, "Something went wrong :(");

                return View(admin);
            }
        }


        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Login(Admin admin)
        {
            try
            {
                var user = _context.Admins.Single(x => x.Email == admin.Email && x.Password == admin.Password);
                if (user != null)
                {
                    HttpContext.Session.SetString("CusId", admin.EmpId.ToString());
                    HttpContext.Session.SetString("Email", admin.Email.ToString());
                    return RedirectToAction("Index1", "Car");

                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Email or Password is invalid");
                    return View();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong");

                return View();
            }

        }
    }
}
