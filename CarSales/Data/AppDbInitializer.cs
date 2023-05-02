using System.Collections.Generic;
using System.Linq;
using CarSales.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CarSales.Data
{
    public class AppDbInitializer
    {

        public static void seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Customers
                if (!context.Customers.Any())
                {
                    context.Customers.AddRange(new List<Customer>()
                    {
                        new Customer()
                        {
                            FirstName = "Fumani",
                            LastName = "Mathebula",
                            Email = "fumanimathebula16@gmail.com",
                            Password = "Admin@12345"
                        }
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
