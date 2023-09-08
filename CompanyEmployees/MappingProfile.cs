using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.Shared.DataTransferObjects;

namespace CompanyEmployees
{
    public class MappingProfile : Profile //Profile is AutoMapper class
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(companyDto => companyDto.FullAddress, opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));

            CreateMap<Employee, EmployeeDto>();
            CreateMap<CompanyForCreationDto, Company>();
            CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<EmployeeForUpdateDto, Employee>();
            CreateMap<CompanyForUpdateDto, Company>();
        }

        //CreateMap method - specify the source object and the destination object to map to.
        //specify additional mapping rules with the ForCtorParam method -to specify the name of the parameter in the constructor that AutoMapper needs to map to.
        //specify additional mapping rules with the ForMember method -to specify the name of the property that AutoMapper needs to map to.
    }
}
