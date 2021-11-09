using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abstractions;
using Abstractions.DTOs.Admin;
using Abstractions.Entities;
using Abstractions.Services.Admin;
using AutoMapper;

namespace BLL.Services.Admin
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

        public async Task<List<OrderDto>> GetAllAsync() =>
            (await _uow.OrderRepository.GetAllAsync())
            .Select(it => _mapper.Map<Order, OrderDto>(it))
            .ToList();

        public async Task<OrderDto> GetAsync(int id) =>
            _mapper.Map<Order, OrderDto>(await _uow.OrderRepository.GetByIdAsync(id));
    }
}