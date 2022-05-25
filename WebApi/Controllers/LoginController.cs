using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;
using WebApi.DTO;
using WebApiDomain.Interfaces.Logic;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginLogic _loginLogic;
        public LoginController(ILoginLogic loginLogic)
        {
            _loginLogic = loginLogic;
        }

        [HttpPost("access-token")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(AccessTokenResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAccessToken([FromBody] AccessTokenRequest request)
        {
            return Ok(await _loginLogic.GetAccessTokenAsync(request));
        }
    }
}
