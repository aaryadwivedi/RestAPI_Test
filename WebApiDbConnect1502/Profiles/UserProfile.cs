using AutoMapper;
using WebApiDbConnect1502.DTO;
using WebApiDbConnect1502.Models;

namespace WebApiDbConnect1502.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() {
            CreateMap<User, UserDTO>().ForMember(dto => dto.UserId, option=>option.MapFrom(usr=>usr.Id)).
                ReverseMap(); //can chain
        }
    }
}
