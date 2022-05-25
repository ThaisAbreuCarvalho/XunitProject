using FluentValidation;
using WebApiDomain.Model;

namespace WebApiDomain.Validator
{
    public class AccessTokenValidator : AbstractValidator<AccessTokenRequest>
    {
        public AccessTokenValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().EmailAddress().WithMessage("Invalid user email");
            RuleFor(x => x.Password).NotEmpty().Must(BeInValidFormat).WithMessage("Invalid password");
        }

        public bool BeInValidFormat(string username)
        {
            return true;
        }
    }
}
