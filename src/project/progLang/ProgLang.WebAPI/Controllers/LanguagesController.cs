using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgLang.Application.Features.Languages.Commands.CreateLanguage;
using ProgLang.Application.Features.Languages.Dtos;
using ProgLang.Application.Features.Languages.Models;
using ProgLang.Application.Features.Languages.Queries.GetByIdLanguage;
using ProgLang.Application.Features.Languages.Queries.GetListLanguage;

namespace ProgLang.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateLanguageCommand createLanguageCommand)
        {
            CreatedLanguageDto result = await Mediator.Send(createLanguageCommand);
            return Created("", result);
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLanguageQuery getListLanguageQuery = new() { PageRequest = pageRequest };
            LanguageListModel result = await Mediator.Send(getListLanguageQuery);
            return Ok(result);
        }
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdLanguageQuery getByIdLanguageQuery)
        {
            LanguageGetByIdDto result = await Mediator.Send(getByIdLanguageQuery);
            return Ok(result);
        }
    }
}
