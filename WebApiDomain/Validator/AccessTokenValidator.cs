using FluentValidation;
using System.Linq;
using WebApiDomain.Model;

namespace WebApiDomain.Validator
{
    public class AccessTokenValidator : AbstractValidator<AccessTokenRequest>
    {
        public AccessTokenValidator()
        {
            RuleFor(x => x.UserEmail)
                .NotEmpty().WithMessage("Invalid user email")
                .EmailAddress().WithMessage("Invalid user email");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Invalid password")
                .Must(BeInValidFormat).WithMessage("Invalid password"); ;
        }

        private bool BeInValidFormat(string password)
        {
            var result = true;

            if (password != null)
            {
                if (password.Length > 12 ||
                    password.All(char.IsDigit) ||
                    password.All(char.IsLetter) ||
                    password.Any(char.IsWhiteSpace))
                    result = false;
            }

            return result;
        }
    }
}
