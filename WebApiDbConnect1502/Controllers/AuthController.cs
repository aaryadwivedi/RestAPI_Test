using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApiDbConnect1502.DTO;
using WebApiDbConnect1502.Models;
using WebApiDbConnect1502.Repository;
using WebApiDbConnect1502.Token;
using WebApiDbConnect1502.Validations;

namespace WebApiDbConnect1502.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly iLoginRepository _loginRepository;
        private readonly iTokenHandler tokenHandler;
        private IMapper mapper;
        public AuthController(iLoginRepository loginRepository, iTokenHandler tok, IMapper mapper)
        {
            this._loginRepository = loginRepository;
            this.tokenHandler= tok;
            this.mapper=mapper;
        }
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO userdto)
        {
            var user = new User { UserName = userdto.UserName, Password = userdto.Password};
            //if(IsLoginValid(userdto))
            {
                var result = await _loginRepository.AuthenticateAsync(userdto.UserName, userdto.Password);
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
            //return userdto;
        }

        private bool IsLoginValid(User user)
        {
            //LoginValidation lgv=new LoginValidation();
            //ValidationResult Result = lgv.Validate(user);
            //if(!Result)
            //{

            //}
            return true;
        }
    }
}
