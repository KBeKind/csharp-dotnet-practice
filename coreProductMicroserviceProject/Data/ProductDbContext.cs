using coreProductMicroserviceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace coreProductMicroserviceProject.Data
{
	public class ProductDbContext:DbContext
	{

		public DbSet<Product> Products { get; set; }

		public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }



	}
}
