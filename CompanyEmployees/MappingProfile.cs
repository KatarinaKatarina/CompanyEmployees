using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects.Shared.DataTransferObjects;

namespace CompanyEmployees
{
    public class MappingProfile : Profile //Profile is Automapper class
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForCtorParam("FullAddress", opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));
        }

        //CreateMap method - specify the source object and the destination object to map to.
        //specify additional mapping rules with the ForCtorParam method -to specify the name of the parameter in the constructor that AutoMapper needs to map to.
    }
}
