using Microsoft.AspNetCore.Mvc;
using Products.Domain.IService;
using Products.Infrastructure;
using Products.Infrastructure.Service;
using Products.Domain.Model.Product;

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
                return BadRequest(ex.InnerException?.ToString());
            }
        }

        [HttpGet]
        [Route("GetProduct")]
        public IActionResult GetProduct(int TenantId, int ProductId)
        {
            try
            {
                var response = _productService.Get<Product>(x => x.TenantId == TenantId && x.ProductId == ProductId).Result;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.ToString());
            }
        }

        [HttpPost]
        [Route("CreateProduct")]
        public IActionResult CreateProduct(Product model)
        {
            try
            {
                var response = _productService.Add(model);
                return Ok(response.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.ToString());
            }
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public IActionResult UpdateProduct(Product model)
        {
            try
            {
                var response = _productService.Update(model);
                return Ok(response.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.ToString());
            }
        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public IActionResult DeleteProduct(Product model)
        {
            try
            {
                var response = _productService.Delete(model);
                return Ok(response.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.ToString());
            }
        }
    }
}