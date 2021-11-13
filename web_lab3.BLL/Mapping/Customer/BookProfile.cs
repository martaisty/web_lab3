using Abstractions.DTOs.Customer;
using Abstractions.Entities;
using AutoMapper;

namespace BLL.Mapping.Customer
{
    internal class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>();
        }
    }
}