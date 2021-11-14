using System.Linq;
using Abstractions.Entities;
using Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    internal class OrderRepository : BaseRepository<Order, int>, IOrderRepository
    {
        public OrderRepository(DatabaseContext context) : base(context)
        {
        }

        protected override IQueryable<Order> ComplexEntities =>
            Context.Orders
                .Include(o => o.Books)
                .ThenInclude(b => b.Sages)
                .Include(o => o.OrdersDetails)
                .Include(o => o.Customer)
                .AsTracking();
    }
}