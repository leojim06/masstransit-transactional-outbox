using MassTransit.Mediator;

namespace Components.Contracts
{
    public record CreateOrganization
    {
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
    }
}
