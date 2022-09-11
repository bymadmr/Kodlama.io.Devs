using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgLang.Application.Features.Technologies.Commands.CreateTechnology;
using ProgLang.Application.Features.Technologies.Commands.DeleteTechnology;
using ProgLang.Application.Features.Technologies.Commands.UpdateTechnology;
using ProgLang.Application.Features.Technologies.Dtos;
using ProgLang.Application.Features.Technologies.Models;
using ProgLang.Application.Features.Technologies.Queries.GetByIdTechnology;
using ProgLang.Application.Features.Technologies.Queries.GetListTechnology;
using ProgLang.Application.Features.Technologies.Queries.GetListTechnologyByDynamic;

namespace ProgLang.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecgnologiesController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateTechnologyCommand createTechnologyCommand)
        {
            CreatedTechnologyDto result = await Mediator.Send(createTechnologyCommand);
            return Created("", result);
        }
        [HttpGet("Getlist")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListTechnologyQuery getListTechnologyQuery = new() { PageRequest = pageRequest };
            TechnologyListModel result = await Mediator.Send(getListTechnologyQuery);
            return Ok(result);
        }
        [HttpPost("Getlist/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListTechnologyByDynamicQuery getListModelByDynamic = new() { PageRequest = pageRequest, Dynamic = dynamic };
            TechnologyListModel result = await Mediator.Send(getListModelByDynamic);
            return Ok(result);
        }
        [HttpGet(("GetById/{Id}"))]
        public async Task<IActionResult> GetById([FromRoute] GetByIdTechnologyQuery getByIdTechnologyQuery)
        {
            TechnologyGetByIdDto result = await Mediator.Send(getByIdTechnologyQuery);
            return Ok(result);
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteTechnologyCommand deleteTechnologyCommand)
        {
            DeletedTechnologyDto result = await Mediator.Send(deleteTechnologyCommand);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateTechnologyCommand updateTechnologyCommand)
        {
            UpdatedTechnologyDto result = await Mediator.Send(updateTechnologyCommand);
            return Ok(result);
        }

    }
}
