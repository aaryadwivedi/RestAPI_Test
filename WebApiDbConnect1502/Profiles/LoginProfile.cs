using AutoMapper;
using WebApiDbConnect1502.DTO;
using WebApiDbConnect1502.Models;

namespace WebApiDbConnect1502.Profiles
{
    public class LoginProfile :Profile
    {
        public LoginProfile() {
            CreateMap<UserLogin, UserLoginDTO>().ReverseMap();
        }
    }
}
