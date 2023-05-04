using System.Threading.Tasks;
using CarSales.Data.Services;
using CarSales.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarSales.Controllers
{
    public class CustomerController : Controller
    {
        private readonly UserManager<Customer> _userManager;
        private readonly SignInManager<Customer> _signInManager;
        private readonly ICustomerService _service;

        public CustomerController(UserManager<Customer> userManager, SignInManager<Customer> signInManager, ICustomerService service)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _service = service;
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
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Email,Password")] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            //var user = await _userManager.FindByEmailAsync(customer.Email);
            var user = await _service.GetUserByEmail(customer.Email);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(customer);
            }

            _service.Add(customer);
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Email,Password")] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }
            _service.Add(customer);
            return RedirectToAction(nameof(Index));
        }

        /*
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
