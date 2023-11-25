using Catalog.API.Entities;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using System.Net;

namespace Catalog.API.Controllers
{
    [Route("api/v1/catalog")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<CatalogController> _logger;
        public CatalogController(IProductRepository productRepository, ILogger<CatalogController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepository.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id:length(24)}", Name ="getProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]   
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]           
        public async Task<ActionResult<Product>> GetProductById(string id)
        {
            var product = await _productRepository.GetProductAsync(id);
            return Ok(product);
        }

        [HttpGet("{category}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(string category)
        {
            var product = await _productRepository.GetProductsByCategory(category);
            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> Post([FromBody] Product product)
        {
             await _productRepository.AddAsync(product);
            return CreatedAtRoute("getProduct", new {id= product.Id }, product);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            bool result = await _productRepository.UpdateAsync(product);
            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(string id)
        {
            bool result = await _productRepository.DeleteAsync(id);
            return Ok(result);
        }
    }
}
