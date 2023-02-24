using Components.Contracts;
using Components.Interfaces;
using MassTransit;

namespace Components.Consumers
{
    public class OrganizationHandler : IConsumer<CreateOrganization>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IUnitOfWork _unitOfWork;

        public OrganizationHandler(IPublishEndpoint publishEndpoint,
            IUnitOfWork unitOfWork)
        {
            _publishEndpoint = publishEndpoint;
            _unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<CreateOrganization> context)
        {
            var message = context.Message;

            var organization = new Organization
            {
                Id = Guid.NewGuid(),
                Name = message.Name,
                Description = message.Description,
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
        }
    }
}
