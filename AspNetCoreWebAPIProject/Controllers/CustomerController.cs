using AspNetCoreWebApiProject.Models;
using AspNetCoreWebAPIProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebAPIProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{

		private ApplicationDbContext _context;

		public CustomerController(ApplicationDbContext context) {

			_context = context;

		}

		[HttpGet]
		public IEnumerable<Customer> GetCustomers()
		{
			return _context.Customers.ToList();

		}


		[HttpGet("{id}")]
		public Customer GetCustomer(int id)
		{
			return _context.Customers.Find(id);
		}


		[HttpPost]
		public IActionResult AddCustomer(Customer customer)
		{
			try
			{
				_context.Customers.Add(customer);
				_context.SaveChanges();
				return StatusCode(StatusCodes.Status201Created, customer);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
		}

		[HttpPut("{id}")]
		public IActionResult UpdateCustomer(int id, Customer customer)
		{

			try
			{
				if(id != customer.Id)
				{
					return StatusCode(StatusCodes.Status400BadRequest);

				}
				else
				{
					_context.Customers.Update(customer);
					_context.SaveChanges();
					return StatusCode(StatusCodes.Status200OK, customer);
				}

			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}


		}


	}
}
