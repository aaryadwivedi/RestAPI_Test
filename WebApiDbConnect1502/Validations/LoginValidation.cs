using FluentValidation;
using WebApiDbConnect1502.Models;

namespace WebApiDbConnect1502.Validations
{
    public class LoginValidation : AbstractValidator<UserLogin>
    {
        public LoginValidation() 
        {
            RuleFor(u => u.Password).NotEmpty().MinimumLength(6).WithMessage("Password must be atleast 6 characters").Matches(@"[\!\?\*\.]+");
            RuleFor(u=>u.UserName).NotEmpty();
        }
    }
}
