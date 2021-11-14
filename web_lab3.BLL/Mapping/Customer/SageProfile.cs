using Abstractions.DTOs.Customer;
using Abstractions.Entities;
using AutoMapper;

namespace BLL.Mapping.Customer
{
    internal class SageProfile : Profile
    {
        public SageProfile()
        {
            CreateMap<Sage, SageDto>();
        }
    }
}