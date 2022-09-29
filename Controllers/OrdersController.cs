using Microsoft.AspNetCore.Mvc;
using smg_erp.Models;

namespace smg_erp.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    // TODO: Get the tenant_id from the token in all routes
    private readonly ILogger<OrdersController> _logger;
    private readonly Context _context;

    public OrdersController(ILogger<OrdersController> logger, Context context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    [Route("Orders")]
    public IActionResult GetAll(int tenantId)
    {
        try
        {
            var res = _context.Orders.Where(order => order.TenantId == tenantId).ToList();
            return Ok(res);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("Order")]
    public IActionResult GetSingle(int tenantId, int orderId)
    {
        try
        {
            var res = _context.Orders.Where(order => order.TenantId == tenantId && order.OrderId == orderId).ToList();
            return Ok(res);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [Route("Order")]
    public IActionResult Create(Order model)
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
    [Route("Order")]
    public IActionResult Update(Order model)
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
    [Route("Order")]
    public IActionResult Delete(Order model)
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