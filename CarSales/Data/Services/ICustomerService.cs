using System.Collections.Generic;
using System.Threading.Tasks;
using CarSales.Models;

namespace CarSales.Data.Services
{
	public interface ICustomerService
	{
		Task<List<Customer>> GetAll();

		Customer GetById(int id);

		void Add(Customer customer);
	}
}
