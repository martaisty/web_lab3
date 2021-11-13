using Abstractions.DTOs.Admin;
using Abstractions.Entities;
using AutoMapper;

namespace BLL.Mapping.Admin
{
    internal class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookDto, Book>()
                .ForMember(b => b.Sages, opt => opt.Ignore());
            
            CreateMap<UpdateBookDto, Book>()
                .ForMember(b => b.Sages, opt => opt.Ignore());
            
            CreateMap<Book, BookDto>();
        }
    }
}