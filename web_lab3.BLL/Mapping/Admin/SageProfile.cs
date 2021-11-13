using Abstractions.DTOs.Admin;
using Abstractions.Entities;
using AutoMapper;

namespace BLL.Mapping.Admin
{
    internal class SageProfile : Profile
    {
        public SageProfile()
        {
            CreateMap<CreateSageDto, Sage>()
                .ForMember(s => s.Books, opt => opt.Ignore());

            CreateMap<UpdateSageDto, Sage>()
                .ForMember(s => s.Books, opt => opt.Ignore());

            CreateMap<Sage, SageDto>();
        }
    }
}