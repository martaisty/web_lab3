using System.Linq;
using System.Threading.Tasks;
using Abstractions;
using Abstractions.DTOs.Customer;
using Abstractions.Entities;
using Abstractions.Services.Customer;
using AutoMapper;

namespace BLL.Services.Customer
{
    internal class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public OrderService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task CreateOrder(NewOrderDto dto, string userId)
        {
            var order = _mapper.Map<NewOrderDto, Order>(dto);
            var details = dto.Books.Select(it => new OrdersBooks
            {
                Order = order,
                BookId = it.BookId,
                Number = it.Quantity
            });
            order.CustomerId = userId;
            order.OrdersDetails = details.ToList();

            await _uow.OrderRepository.InsertAsync(order);
            await _uow.SaveAsync();
        }
    }
}