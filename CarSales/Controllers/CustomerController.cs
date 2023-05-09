using System;
using System.Linq;
using System.Threading.Tasks;
using CarSales.Data;
using CarSales.Models;
using CarSales.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace CarSales.Controllers
{
    public class CustomerController : Controller
    {
        private readonly UserManager<Customer> _userManager;
        private readonly SignInManager<Customer> _signInManager;
        private readonly ICustomerService _service;
        private readonly AppDbContext _context;

        public CustomerController(ICustomerService service, AppDbContext context/*UserManager<Customer> userManager, SignInManager<Customer> signInManager, */)
        {
            // _userManager = userManager;
            //_signInManager = signInManager;
            _service = service;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }

        //Get: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Error");
                return View(customer);
            }

            IDbContextTransaction transaction = _context.Database.BeginTransaction();
            try
            {
                //var user = await _userManager.FindByEmailAsync(customer.Email);
                var user = await _service.GetUserByEmail(customer.Email);
                if (user != null)
                {
                    ModelState.AddModelError(string.Empty, "This email address is already in use");
                    //TempData["Error"] = "This email address is already in use";
                    return View(customer);
                }
                else if (customer.Password != customer.ConfirmPassword)
                {
                    ModelState.AddModelError(string.Empty, "Password does not match");
                    return View(customer);
                }

                await _service.AddCustomer(customer);
                transaction.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                ModelState.AddModelError(string.Empty, "Something went wrong :(");

                return View(customer);
            }
        }

        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Login(Customer customer)
        {
            try
            {
                var user = _context.Customers.Single(x => x.Email == customer.Email && x.Password == customer.Password);
                if (user != null)
                {
                    HttpContext.Session.SetInt32("CusId", customer.CusId);
                    HttpContext.Session.SetString("Email", customer.Email.ToString());
                    HttpContext.Session.SetString("FirstName", customer.FirstName.ToString());
                    HttpContext.Session.SetString("LastName", customer.LastName.ToString());
                    return RedirectToAction("Index", "Car");

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

        /*
        public ActionResult LoggedIn()
        {
            if (HttpContext.Session.Equals("CusId"))
            {
                return RedirectToAction("/Car/Index");
            }
            return View();

        }
        
        [HttpPost]
        public async Task<IActionResult> Login(Customer model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToLocal(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToAction(nameof(LoginWith2fa), new { returnUrl, model.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    return RedirectToAction(nameof(Lockout));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            return View(model);
        }*/
    }


}
