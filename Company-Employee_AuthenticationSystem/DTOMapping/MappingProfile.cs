using AutoMapper;
using Company_Employee_AuthenticationSystem.DTO;

namespace Company_Employee_AuthenticationSystem.DTOMapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDTO, ApplicationUser>().ReverseMap();        }
    }
}
