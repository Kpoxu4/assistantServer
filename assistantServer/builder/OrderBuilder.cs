using assistantServer.builder.Interface;
using assistantServer.data.model;
using assistantServer.data.repository.Interface;
using assistantServer.Models;

namespace assistantServer.builder
{
    public class OrderBuilder : IOrderBuilder
    {
        public const int DAY_IN_WEEK = 7;
        private readonly IUserRepository _userRepository;

        public OrderBuilder(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Order BuildOrder(CreateOrderModel model)
        {
            var dateNow = DateTime.Now;
            var user = _userRepository.Get(model.UserId);

            return new Order
            {
                FirstLastName = model.FirstLastName,
                Address = model.Address,
                Phone = model.Phone,
                ProductName = model.ProductName,
                ProductPrice = model.ProductPrice,
                ProductionTime = model.ProductionTime,
                AdvancePayment = model.AdvancePayment,
                CreateDate = dateNow.ToString("yyyy-MM-dd HH:mm:ss"),
                FinishDate = dateNow.AddDays(DAY_IN_WEEK * model.ProductionTime).ToString("yyyy-MM-dd HH:mm:ss"),
                IsOverdue = false,
                User = user!
            };
        }
    }
}

