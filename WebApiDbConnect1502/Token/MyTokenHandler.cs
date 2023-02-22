using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiDbConnect1502.Models;

namespace WebApiDbConnect1502.Token
{
    public class MyTokenHandler : iTokenHandler
    {
        private readonly IConfiguration Configuration;

        public MyTokenHandler(IConfiguration configuration) 
        {
            this.Configuration = configuration;
        }
        public async Task<string> CreateToken(UserLogin user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName, user.UserName));
            claims.Add(new Claim(ClaimTypes.Role, user.Role));

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(Key,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    Configuration["Jwt:Issuer"],
                    Configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddSeconds(100),
                    signingCredentials: credentials
                );
            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
        public async Task<string> CreateToken(LoginMaster user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName, user.UserName));
            claims.Add(new Claim(ClaimTypes.Role, user.Roles.RoleName));

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    Configuration["Jwt:Issuer"],
                    Configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddSeconds(100),
                    signingCredentials: credentials
                );
            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
