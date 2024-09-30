using assistantServer.data.model;
using assistantServer.Models;

namespace assistantServer.builder.Interface
{
    public interface IOrderBuilder
    {
        Order BuildOrder(CreateOrderModel model);
    }
}
