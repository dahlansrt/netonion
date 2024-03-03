using Application.Features.Products.Queries;
using Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IMediator mediator) : BaseController(mediator)
    {
        public async Task<ActionResult<IEnumerable<ProductResponse>>> Get()
        {
            return Ok(await Mediator.Send(new GetProductsQuery()));
        }
    }
}
