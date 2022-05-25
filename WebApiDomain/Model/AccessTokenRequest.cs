using FluentValidation.Results;
using System.Threading.Tasks;
using WebApiDomain.Validator;

namespace WebApiDomain.Model
{
    public class AccessTokenRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public async Task<ValidationResult> IsValid()
        {
            var validator = new AccessTokenValidator();
            return await validator.ValidateAsync(this).ConfigureAwait(false);
        }
    }
}
