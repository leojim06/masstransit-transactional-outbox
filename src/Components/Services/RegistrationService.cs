using Components.Contracts;
using Components.Interfaces;
using MassTransit;

namespace Components.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IUnitOfWork _unitOfWork;

        public RegistrationService(IPublishEndpoint publishEndpoint,
            IUnitOfWork unitOfWork)
        {
            _publishEndpoint = publishEndpoint;
            _unitOfWork = unitOfWork;
        }

        public async Task<Organization> Send(string name, string description)
        {
            var organization = new Organization
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                CreatedAtUtc = DateTime.UtcNow,
            };

            await _unitOfWork.OrganizationRepository.AddAsync(organization);

            await _publishEndpoint.Publish(new MessageSubmitted
            {
                Id = organization.Id,
                Name = organization.Name,
                Description = organization.Description,
                CreatedAtUtc = organization.CreatedAtUtc,
            });

            await _unitOfWork.SaveChangesAsync();
            return organization;
        }
    }
}
