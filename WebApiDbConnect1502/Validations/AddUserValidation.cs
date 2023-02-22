using FluentValidation;
using WebApiDbConnect1502.Models;

namespace WebApiDbConnect1502.Validations
{
    public class AddUserValidation: AbstractValidator<User>
    {
        public AddUserValidation()
        { 
            RuleFor(u=>u.UserName).NotEmpty();
            RuleFor(u=>u.FirstName).NotEmpty();
        }
    }
}
