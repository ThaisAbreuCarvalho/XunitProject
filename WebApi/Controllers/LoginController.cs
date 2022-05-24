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
        private readonly ILogger _logger;
        private readonly ILoginLogic _loginLogic;
        public LoginController(ILogger logger, ILoginLogic loginLogic)
        {
            _logger = logger;
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
