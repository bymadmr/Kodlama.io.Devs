using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgLang.Application.Features.Auth.Login.Dtos;
using ProgLang.Application.Features.Auth.Login.Queries.Login;
using ProgLang.Application.Features.Auth.Register.Dtos;
using ProgLang.Application.Features.Auth.Register.Queries.Register;

namespace ProgLang.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterQuery registerQuery)
        {
            RegisterAccessTokenDto result = await Mediator.Send(registerQuery);
            return Ok(result);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginQuery loginQuery)
        {
            LoginAccessTokenDto result = await Mediator.Send(loginQuery);
            return Ok( result);
        }
    }
}
