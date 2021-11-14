using Abstractions.DTOs.Admin;
using Abstractions.Entities;
using AutoMapper;

namespace BLL.Mapping.Admin
{
    internal class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(o => o.Books, opt => opt.MapFrom(o => o.OrdersDetails));

            CreateMap<OrdersBooks, OrderedBookDto>()
                .ForMember(b => b.Id, opt => opt.MapFrom(o => o.Book.Id))
                .ForMember(b => b.Name, opt => opt.MapFrom(o => o.Book.Name))
                .ForMember(b => b.Description, opt => opt.MapFrom(o => o.Book.Description))
                .ForMember(b => b.Sages, opt => opt.MapFrom(o => o.Book.Sages))
                .ForMember(b => b.Quantity, opt => opt.MapFrom(o => o.Number));
        }
    }
}