using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiDbConnect1502.DTO;
using WebApiDbConnect1502.Models;
using WebApiDbConnect1502.Repository;
using WebApiDbConnect1502.Token;

namespace WebApiDbConnect1502.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private iNewLogin newLogin;
        private readonly iTokenHandler tokenHandler;
        private IMapper mapper;


        public LoginController(iNewLogin loginRepository, iTokenHandler tok, IMapper mapper)
        {
            this.newLogin = loginRepository;
            this.tokenHandler = tok;
            this.mapper = mapper;
        }
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginMasterDTO loginMasterDTO)
        {

            //var user = new User { UserName = userdto.UserName, Password = userdto.Password };
            //if(IsLoginValid(userdto))
            {
                var result = await newLogin.AuthenticateAsync(loginMasterDTO.UserName, loginMasterDTO.Password);
                if (result != null)
                {
                    var x = await this.tokenHandler.CreateToken(result);
                    return Ok(x);
                }
                else
                {
                    return BadRequest("Username is required and Password must have 6 characters with 1 special case");
                }
            }
            return BadRequest("Credentials not valid");
        }
    }
}
