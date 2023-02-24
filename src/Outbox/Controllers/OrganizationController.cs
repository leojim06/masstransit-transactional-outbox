using Components.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Outbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private IRegistrationService _registrationService;

        public OrganizationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        public async Task<IActionResult> Send(
            [FromBody] OrganizationModel organization)
        {
            var result = await _registrationService.Send(
                organization.Name,
                organization.Description);

            return Ok(result);
        }
    }
}
