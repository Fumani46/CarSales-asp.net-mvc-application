using System;
using System.Linq;
using System.Threading.Tasks;
using CarSales.Data;
using CarSales.Models;
using CarSales.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
