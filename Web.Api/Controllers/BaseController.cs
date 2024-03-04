using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator mediator = mediator;
        protected IMediator Mediator => this.mediator;
    }
}
