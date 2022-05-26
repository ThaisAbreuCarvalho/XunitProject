using FluentValidation;
using System.Linq;
using WebApiDomain.Model;

namespace WebApiDomain.Validator
{
    public class AccessTokenValidator : AbstractValidator<AccessTokenRequest>
    {
        public AccessTokenValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Invalid user email")
                .EmailAddress().WithMessage("Invalid user email");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Invalid password")
                .Must(BeInValidFormat).WithMessage("Invalid password"); ;
        }

        public bool BeInValidFormat(string username)
        {
            var result = true;

            if (username != null)
            {
                if (username.Length != 8 ||
                    username.All(char.IsDigit) || 
                    username.All(char.IsLetter) || 
                    username.Any(char.IsWhiteSpace))
                    result = false; 
            }

            return result;
        }
    }
}
