using Abstractions.DTOs.Customer;
using Abstractions.Entities;
using AutoMapper;

namespace BLL.Mapping.Customer
{
    internal class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<NewOrderDto, Order>()
                .ForMember(o => o.Books, opt => opt.Ignore());
        }
    }
}