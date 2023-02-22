using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApiDbConnect1502.DTO;
using WebApiDbConnect1502.Models;
using WebApiDbConnect1502.Repository;

namespace WebApiDbConnect1502.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository repos;
        private IMapper mapper;

        //contructor 
        public UserController(IUserRepository repos, IMapper mapper)
        {
            this.repos = repos;
            this.mapper = mapper;
        }
        [Route("")]
        [HttpGet]


        //fetch users with dto
        public async Task<IActionResult>GetAllUsers()
        {
            var users = await this.repos.GetUsers();
            //var usersdto = new List<UserDTO>();
            //foreach(var user in users)
            //{
            //    UserDTO u = new UserDTO();
            //    u.UserId= user.Id;
            //    u.FirstName= user.FirstName;
            //    u.LastName= user.LastName;
            //    u.UserName = user.UserName;
            //    u.Password = user.Password;
            //    usersdto.Add(u);
            //}
            var usersdto=mapper.Map<List<UserDTO>>(users);
            return Ok(usersdto);
        }
        [Route("getusers")]
        [HttpGet]


        //fetch users without dto
        public async Task<IActionResult> GetUsers()
        {
            //return this.repos.GetUsers();
            //return Users;
            return Ok(await this.repos.GetUsers());
        }
        [Route("getusers/{id}")]
        [Authorize]
        [HttpGet]


        //fetch user by id
        public async Task<IActionResult> GetUserById(int id)
        {
            //return this.repos.GetUserById(id);
            //return user;
            var user=await this.repos.GetUserById(id);
            var usersdto = mapper.Map<UserDTO>(user);
            if (usersdto!=null)
            {
                return Ok(usersdto); //200
            }
            return NotFound();
        }
        //[Route("adduser")]
        //[HttpPost]


        //add user
        //public async Task<IActionResult> AddUser(User user)
        //{
        //    await repos.AddUser(user);
        //    //return Created("", user); //201
        //    return Ok(user);
        //}



        //update user
        //public async Task<IActionResult> UpdateUser(User user)
        //{
        //    await repos.UpdateUser(user);
        //    //return Created("", user); //201
        //    return Ok(user);
        //}
        [Route("updateuser")]
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserDTO userdto)
        {
            var user = mapper.Map<User>(userdto);
            var d=ValidUpdateUser(user);
            if(d.ErrorCount==0)
            {
                await this.repos.UpdateUser(user);
                return Ok(user);
            }
            return BadRequest(d);
        }
        [Route("deleteuser/{id}")]
        [Authorize]
        [HttpDelete]
        //delete user
        public async Task<IActionResult> DeleteUser(int id)
        {

            await repos.DeleteUser(id);
            //return Created("", user); //201
            return Ok(id);
        }
        [Route("adduser")]
        [HttpPost]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        //[Authorize(Roles ="author")]
        public async Task<IActionResult> AddUser(User userdto)
        {
            var user = mapper.Map<User>(userdto);
            if(ValidAddUser(user))
            {
                await this.repos.AddUser(user);
                return Ok(user);
            }
            return BadRequest();
        }
        private bool ValidAddUser(User user)
        {
            if (user == null)
            {
                ModelState.AddModelError(nameof(user), "User cannot be null");
                return false;
            }
            if(string.IsNullOrWhiteSpace(user.UserName))
            {
                ModelState.AddModelError(nameof(user), "User name cannot be empty");
                return false;
            }
            if(string.IsNullOrWhiteSpace(user.FirstName))
            {
                ModelState.AddModelError(nameof(user), "First Name cannot be empty");
            }
            if(ModelState.ErrorCount>0)
            {
                return false;
            }
            return true;
        }

        private ModelStateDictionary ValidUpdateUser(User user)
        {
            ModelStateDictionary d = new ModelStateDictionary();
            if (user == null)
            {
                d.AddModelError(nameof(user), "User cannot be null");
                return d;
            }
            if (string.IsNullOrWhiteSpace(user.UserName))
            {
                ModelState.AddModelError(nameof(user), "User name cannot be empty");
                //return false;
            }
            if (string.IsNullOrWhiteSpace(user.FirstName))
            {
                ModelState.AddModelError(nameof(user), "First Name cannot be empty");
            }
            if (ModelState.ErrorCount > 0)
            {
                //return false;
                return d;
            }
            return d;
        }


    }
}
