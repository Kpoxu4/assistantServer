using assistantServer.builder.Interface;
using assistantServer.data.model;
using assistantServer.data.repository.Interface;
using assistantServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace assistantServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrderBuilder _orderBuilder; 
        private readonly IOrderRepository _orderRepository; 

        public OrderController(IUserRepository userRepository, IOrderBuilder orderBuilder, IOrderRepository orderRepository)
        {
            _userRepository = userRepository;
            _orderBuilder = orderBuilder;
            _orderRepository = orderRepository;
        }

        [HttpPost("createOrder")]
        public IActionResult CreateOrder([FromBody] CreateOrderModel apiModel)
        {
            if (apiModel.ProductPrice < apiModel.AdvancePayment)
            {
                return BadRequest(new { error = "Цена должна быть больше или ровной с предоплатой." });
            }
            if (_userRepository.Get(apiModel.UserId) == null)
            {
                return BadRequest(new { error = "Извините но что-то пошло не так с вашей регистрацией." });
            }

            var order = _orderBuilder.BuildOrder(apiModel);

            _orderRepository.Create(order);

            return Ok();
        }
    }
}
