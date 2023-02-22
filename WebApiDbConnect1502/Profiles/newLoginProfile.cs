using AutoMapper;
using WebApiDbConnect1502.DTO;
using WebApiDbConnect1502.Models;

namespace WebApiDbConnect1502.Profiles
{
    public class newLoginProfile : Profile
    {
        public newLoginProfile() 
        {
            CreateMap<LoginMaster, LoginMasterDTO>().ReverseMap();
        }
    }
}