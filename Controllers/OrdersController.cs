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
    public IActionResult GetAll()
    {
        try
        {
            var res = _context.Orders.ToList();
            return Ok(res);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

    }

}