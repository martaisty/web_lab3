using Abstractions.DTOs.Customer;
using Abstractions.Entities;
using AutoMapper;
using SageDto = Abstractions.DTOs.Admin.SageDto;

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