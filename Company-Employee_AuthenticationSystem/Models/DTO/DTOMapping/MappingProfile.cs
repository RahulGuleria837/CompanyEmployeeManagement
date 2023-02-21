using AutoMapper;
using Company_Employee_AuthenticationSystem.DTO;
using Company_Employee_AuthenticationSystem.Models;

namespace Company_Employee_AuthenticationSystem.Models.DTO.DTOMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDTO, ApplicationUser>().ReverseMap();
            CreateMap<CompanyDTO, Company>().ReverseMap();
            CreateMap<EmployeeDTO, Employee>().ReverseMap();    


        }
    }
}
