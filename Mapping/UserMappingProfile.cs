using AutoMapper;
using final_crud.Models;
using final_crud.DTOs.User;

namespace final_crud.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserResponseDtoV2>();
            CreateMap<RegisterUserDto, User>();
            CreateMap<User, LoginResult>();
        } 

    }
}
