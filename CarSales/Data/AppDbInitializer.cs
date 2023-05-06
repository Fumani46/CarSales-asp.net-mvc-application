using System;
using System.Collections.Generic;
using System.Linq;
using CarSales.Models;
using CarSales.Models.Items;
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

                //Admin
                if (!context.Admins.Any())
                {
                    context.Admins.AddRange(new List<Admin>()
                    {
                        new Admin()
                        {
                            FirstName = "Levi",
                            LastName = "Mathebula",
                            Email = "fumani20@gmail.com",
                            Password = "Admin@123"
                        }
                    });

                    context.SaveChanges();
                }
                //Agent
                if (!context.Agents.Any())
                {
                    context.Agents.AddRange(new List<Agent>()
                    {
                        new Agent()
                        {
                            FirstName = "Nick",
                            LastName = "Canon",
                            Email = "NickCan@gmail.com",
                            Password = "Admin@12"
                        }
                    });

                    context.SaveChanges();
                }
                //Car
                if (!context.Cars.Any())
                {
                    context.Cars.AddRange(new List<Car>()
                    {
                        new Car()
                        {
                            CarName = "BMW",
                            CarModel = "M4",
                            Color = "Black",
                            Year = Convert.ToDateTime("02/20/2020"),
                            Type = "Hashback",
                            PictureUrl = "https://wallpaperaccess.com/full/7115528.jpg",
                            Price = 2000.00
                        },
                        new Car()
                        {
                            CarName = "AUDI",
                            CarModel = "RS3",
                            Color = "Coal",
                            Year = Convert.ToDateTime("02/20/2021"),
                            Type = "Private",
                            PictureUrl = "https://img-ik.cars.co.za/news-site-za/images/2022/09/Audi-RS-3-Sedan-072_1800x1800.jpg?tr=w-1200,h-800",
                            Price = 90000.00
                        },
                        new Car()
                        {
                            CarName = "Benz",
                            CarModel = "AMG A45",
                            Color = "Yellow",
                            Year = Convert.ToDateTime("02/20/2019"),
                            Type = "Hashback",
                            PictureUrl = "https://www.topgear.com/sites/default/files/cars-car/image/2019/07/19c0577_024.jpg",
                            Price = 50000.00
                        },
                        new Car()
                        {
                            CarName = "AUDI",
                            CarModel = "RSQ4",
                            Color = "Red",
                            Year = Convert.ToDateTime("02/20/2022"),
                            Type = "Private",
                            PictureUrl = "https://www.topgear.com/sites/default/files/cars-car/image/2020/04/audi_rs4_morocco_cjordan_butters-79.jpg",
                            Price = 4000.00
                        }
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
