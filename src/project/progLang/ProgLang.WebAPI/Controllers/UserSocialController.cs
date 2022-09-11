using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgLang.Application.Features.Socials.Commands.CreateUserSocial;
using ProgLang.Application.Features.Socials.Commands.DeleteUserSocial;
using ProgLang.Application.Features.Socials.Commands.UpdateUserSocial;
using ProgLang.Application.Features.Socials.Dtos;
using ProgLang.Application.Features.Socials.Queries.GetByUserIdUserSocial;

namespace ProgLang.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSocialController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateUserSocialCommand createUserSocialCommand)
        {
            CreatedUserSocialDto result = await Mediator.Send(createUserSocialCommand);
            return Created("", result);
        }
       
        [HttpPost("GetByUserSocialId")]
        public async Task<IActionResult> GetById([FromBody] GetByUserIdUserSocialQuery getByUserIdUserSocialQuery)
        {
            UserSocialGetByUserIdDto result = await Mediator.Send(getByUserIdUserSocialQuery);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteUserSocialCommand deleteUserSocialCommand)
        {
            DeletedUserSocialDto result = await Mediator.Send(deleteUserSocialCommand);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserSocialCommand updateUserSocialCommand)
        {
            UpdatedUserSocialDto result = await Mediator.Send(updateUserSocialCommand);
            return Ok(result);
        }
    }
}
