﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CarSales.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CarSales.Data;

namespace CarSales.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly AppDbContext _context;
		public CustomerService(AppDbContext context)
		{
			_context = context;
		}

		public void Add(Customer customer)
		{
			_context.Customers.Add(customer);
			_context.SaveChanges();
		}

		public async Task<List<Customer>> GetAll()
		{

			var result = await _context.Customers.ToListAsync();
			return result;
		}

		public Customer GetById(int id)
		{
			throw new System.NotImplementedException();
		}

		public async Task<Customer> GetUserByEmail(string email)
		{
			var user = (await _context.Customers.ToListAsync()).FirstOrDefault(x => x.Email == email);

			return user;
		}

	}
}