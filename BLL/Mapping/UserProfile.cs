using Abstractions.DTOs;
using Abstractions.Entities;
using AutoMapper;

namespace BLL.Mapping
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterDto, User>();
        }
    }
}