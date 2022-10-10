using Microsoft.AspNetCore.Mvc;
using smg_erp.Models;

namespace smg_erp.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    // TODO: Get the tenant_id from the token in all routes
    private readonly ILogger<ProductsController> _logger;
    private readonly Context _context;

    public ProductsController(ILogger<ProductsController> logger, Context context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    [Route("Products")]
    public IActionResult GetAll(int tenantId)
    {
        try
        {
            var res = _context.Products.Where(product => product.TenantId == tenantId).ToList();
            return Ok(res);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("Product")]
    public IActionResult GetSingle(int tenantId, int productId)
    {
        try
        {
            var res = _context.Products.Where(product => product.TenantId == tenantId && product.ProductId == productId).ToList();
            return Ok(res);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [Route("Product")]
    public IActionResult Create(Product model)
    {
        try
        {
            var res = _context.Add(model);
            _context.SaveChanges();
            return Ok(res);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    [Route("Product")]
    public IActionResult Update(Product model)
    {
        try
        {
            var res = _context.Update(model);
            _context.SaveChanges();
            return Ok(res);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete]
    [Route("Product")]
    public IActionResult Delete(Product model)
    {
        try
        {
            var res = _context.Remove(model);
            _context.SaveChanges();
            return Ok(res);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}