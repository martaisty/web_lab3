using Abstractions.Entities;

namespace Abstractions.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order, int>
    {
    }
}