using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController(ISender mediator) : ControllerBase
    {
        private readonly ISender mediator = mediator;
        protected ISender Mediator => this.mediator;
    }
}
