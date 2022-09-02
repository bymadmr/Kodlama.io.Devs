using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProgLang.WebAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IMediator? Mediator => HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? _mediator;
    }
}
