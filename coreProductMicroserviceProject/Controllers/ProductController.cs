using coreProductMicroserviceProject.Models;
using coreProductMicroserviceProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace coreProductMicroserviceProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : Controller
	{

		private readonly IProductRepository _productRepository;
		public ProductController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}


		// GET:  api/product
		[HttpGet]
		public IActionResult Get()
		{
			var products = _productRepository.GetProducts();
			return new OkObjectResult(products);
		}

		// GET: api/product/5
		[HttpGet("{id}", Name = "Get")]
		public IActionResult Get(int id)
		{
			var product = _productRepository.GetProductByID(id);
			return new OkObjectResult(product);
		}


		// POST: api/product
		[HttpPost]
		public IActionResult Post([FromBody] Product product)
		{
			using( var scope= new TransactionScope())
			{
				_productRepository.InsertProduct(product);
				scope.Complete();
				return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
			}
		}


		// PUT: api/product/5
		[HttpPut]
		public IActionResult Put([FromBody] Product product)
		{
			if(product != null)
			{
				using (var scope = new TransactionScope())
				{
					_productRepository.UpdateProduct(product);
					scope.Complete();
					return new OkResult();
				}
			}
			return new NoContentResult();
			
		}

		// DELETE: api/apiwithactions/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_productRepository.DeleteProduct(id);
			return new OkResult();
		}
		
	}
}
