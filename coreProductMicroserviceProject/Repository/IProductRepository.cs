using coreProductMicroserviceProject.Models;

namespace coreProductMicroserviceProject.Repository
{
	public interface IProductRepository
	{

		IEnumerable<Product> GetProducts();

		Product GetProductByID(int product);

		void InsertProduct(Product product);

		void DeleteProduct(int productID);
		
		void UpdateProduct(Product product);

		void Save();


	}
}
