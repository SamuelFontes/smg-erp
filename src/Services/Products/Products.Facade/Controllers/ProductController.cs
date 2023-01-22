using Microsoft.AspNetCore.Mvc;
using Products.Domain.IService;
using Products.Infrastructure;
using Products.Infrastructure.Service;

namespace Products.Facade.Controllers
{
    [ApiController]
    [Route("api/Product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService; 
        public ProductController(IProductService productService)
        {
            _productService = productService;    
        }

        [HttpGet]
        [Route("GetProducts")]
        public IActionResult GetProducts()
        {
            try
            {
               var response = _productService.GetAll<Product>(x => true).Result;
               return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}