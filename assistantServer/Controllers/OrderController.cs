using assistantServer.data.model;
using assistantServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace assistantServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpPost("createOrder")]
        public IActionResult CreateOrder([FromBody] CreateOrderModel apiModel)
        {
            if (apiModel.ProductPrice < apiModel.AdvancePayment)
            {
                return BadRequest(new { error = "Цена должна быть больше или ровной с предоплатой" });
            }

            return Ok();
        }

    }
}
