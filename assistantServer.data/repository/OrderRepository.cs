
using assistantServer.data.model;
using assistantServer.data.repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace assistantServer.data.repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(AssistantDbContext dbContext) : base(dbContext){}
    }
}
