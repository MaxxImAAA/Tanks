using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksProject2.Domain.Dtos.UserDtos;

namespace TanksProject2.Domain.Validation
{
    public class UserRegDtosValidation : AbstractValidator<UserRegistrationDtos>
    {
        
        public UserRegDtosValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(10);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(8);

            RuleFor(x => x.NickName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(10);
                
            
        }
    }
}
