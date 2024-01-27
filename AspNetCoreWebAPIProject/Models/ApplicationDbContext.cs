using AspNetCoreWebApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebAPIProject.Models
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Customer> Customers { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
		
	}
}
