using Components.Contracts;
using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Outbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgMediatorController : ControllerBase
    {

        private readonly IMediator _mediator;

        public OrgMediatorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] CreateOrganization command)
        {
            await _mediator.Send(command);
            return Ok(command);
        }
    }
}
