using AutoMapper;
using final_crud.Models;
using final_crud.DTOs.User;

namespace final_crud.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserResponseDtoV2>()
                .ForMember(dest => dest.Token, opt => opt.Ignore());

            CreateMap<RegisterUserDto, User>();

            CreateMap<User, LoginResult>()
                .ForMember(dest => dest.Token, opt => opt.Ignore())
                .ForMember(dest => dest.LoginTime, opt => opt.MapFrom(_ => DateTime.Now));
        } 

    }
}
