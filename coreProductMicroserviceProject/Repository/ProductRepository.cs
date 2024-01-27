using coreProductMicroserviceProject.Data;
using coreProductMicroserviceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace coreProductMicroserviceProject.Repository
{
	public class ProductRepository : IProductRepository
	{

		private readonly ProductDbContext _dbContext;


		public ProductRepository(ProductDbContext context)
		{
			_dbContext = context;
		}

		public void DeleteProduct(int productID)
		{
			var product = _dbContext.Products.Find(productID);
			_dbContext.Products.Remove(product);
			Save();
		}

		public Product GetProductByID(int productID)
		{
			return _dbContext.Products.Find(productID);
		}

		public IEnumerable<Product> GetProducts()
		{
			return _dbContext.Products.ToList();
		}

		public void InsertProduct(Product product)
		{
			_dbContext.Products.Add(product);
			Save();
		}

		public void Save()
		{
			_dbContext.SaveChanges();
		}

		public void UpdateProduct(Product product)
		{
			_dbContext.Entry(product).State = EntityState.Modified;
			Save();
		}
	}
}
