using System.Collections.Generic;
using System.Threading.Tasks;
using CarSales.Models;
using Microsoft.EntityFrameworkCore;

namespace CarSales.Data.Services
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


	}
}
