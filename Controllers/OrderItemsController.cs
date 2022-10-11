using Microsoft.AspNetCore.Mvc;
using smg_erp.Models;

namespace smg_erp.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderItemsController : ControllerBase
{
    // TODO: Get the tenant_id from the token in all routes
    private readonly ILogger<OrderItemsController> _logger;
    private readonly Context _context;

    public OrderItemsController(ILogger<OrderItemsController> logger, Context context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    [Route("OrderItems")]
    public IActionResult GetAll(int tenantId, int productId)
    {
        try
        {
            var res = _context.OrderItems.Where(orderItem => orderItem.TenantId == tenantId && orderItem.ProductId == productId).ToList();
            return Ok(res);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("OrderItem")]
    public IActionResult GetSingle(int tenantId, int productId, int itemId)
    {
        try
        {
            var res = _context.OrderItems.Where(orderItem => orderItem.TenantId == tenantId && orderItem.ProductId == productId && orderItem.ItemId == itemId).ToList();
            return Ok(res);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [Route("OrderItem")]
    public IActionResult Create(OrderItem model)
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
    [Route("OrderItem")]
    public IActionResult Update(OrderItem model)
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
    [Route("OrderItem")]
    public IActionResult Delete(OrderItem model)
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