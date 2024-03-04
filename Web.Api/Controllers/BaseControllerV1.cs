using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Common;

namespace Web.Api.Controllers
{
    public abstract class BaseControllerV1<T, TC>(
        IMediator mediator,
        Storage<T> storage,
        ILogger<TC> logger) : ControllerBase
        where T : BaseEntity
        where TC : ControllerBase
    {
        private readonly IMediator mediator = mediator;
        private readonly Storage<T> storage = storage;
        private readonly ILogger<TC> _logger = logger;

        protected IMediator Mediator => mediator;
        protected Storage<T> Storage => storage;

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            var result = await Storage.GetAsync();
            return Ok(result);
        }

        [HttpGet("{id:length(16)}")]
        public virtual async Task<IActionResult> Get(Guid id)
        {
            var result = await Storage.GetAsync(id);
            if (result is null)
            {
                _logger.LogWarning(AppLogEvents.ReadNotFound, "GetAsync({Id}) not found", id);
                return NotFound();
            }

            _logger.LogInformation(AppLogEvents.Read, "Reading value for {Id}", id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] T value)
        {
            await Storage.AddAsync(value);

            return Created();
        }

        [HttpPut("{id:length(16)}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] T value)
        {
            var result = await Storage.GetAsync(id);
            if (result is null)
            {
                return NotFound();
            }

            await Storage.UpdateAsync(id, value);

            return NoContent();
        }

        [HttpDelete("{id:length(16)}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await Storage.RemoveAsync(id);

            if (!result)
            {
                _logger.LogWarning(AppLogEvents.DeleteNotFound, "RemoveAsync({Id}) not found", id);
                return NotFound();
            }

            return NoContent();
        }
    }
}
