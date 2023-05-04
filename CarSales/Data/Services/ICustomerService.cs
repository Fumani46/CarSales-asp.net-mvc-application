using System.Collections.Generic;
using System.Threading.Tasks;
using CarSales.Models;

namespace CarSales.Data.Services
{
	public interface ICustomerService
	{
		public Task<List<Customer>> GetAll();

		public Customer GetById(int id);

		public void Add(Customer customer);

		public Task<Customer> GetUserByEmail(string email);
	}
}
