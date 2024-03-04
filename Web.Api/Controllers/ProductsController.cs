using Application.Features.Products.Commands;
using Application.Features.Products.Queries;
using Domain.Requests;
using Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IMediator mediator) : BaseController(mediator)
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> Get()
        {
            return Ok(await Mediator.Send(new GetProductsQuery()));
        }

        /// <summary>
        /// TODO: Is IAsyncEnumerable is the right on for this case?
        /// </summary>
        /// <returns></returns>
        //public async Task<ActionResult<IAsyncEnumerable<ProductResponse>>> GetAsync()
        //{
        //    return Ok(await Mediator.Send(new GetProductsQuery()));
        //}
        [HttpGet("{id:length(16)}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            var result = await Mediator.Send(new GetProductQuery(id));
            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductRequest product)
        {
            await Mediator.Send(new CreateProductCommand(product));

            return Created();
        }

        [HttpPut("{id:length(16)}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductCommand product)
        {
            var result = await Mediator.Send(new GetProductQuery(id));
            if (result is null)
            {
                return NotFound();
            }

            await Mediator.Send(product);

            return Created();
        }

        [HttpDelete("{id:length(16)}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new GetProductQuery(id));
            if (result is null)
            {
                return NotFound();
            }
            await Mediator.Send(new DeleteProductCommand(id));

            return NoContent();
        }
    }
}
