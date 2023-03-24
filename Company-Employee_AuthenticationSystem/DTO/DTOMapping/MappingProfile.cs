using AutoMapper;
using Company_Employee_AuthenticationSystem.DTO;
using Company_Employee_AuthenticationSystem.Models;

namespace Company_Employee_AuthenticationSystem.DTO.DTOMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDTO, ApplicationUser>().ReverseMap();
            CreateMap<CompanyDTO, Company>().ReverseMap();
            CreateMap<EmployeeDTO, Employee>().ReverseMap();
            CreateMap<DesignationDTO, Designation>().ReverseMap();
            CreateMap<EmployeeDesignationDTO, EmployeeDesignation>().ReverseMap();
            CreateMap<LeaveDTO, Leave>().ReverseMap();


        }
    }
}
