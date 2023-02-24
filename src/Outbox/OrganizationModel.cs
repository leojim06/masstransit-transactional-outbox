namespace Outbox
{
    public record OrganizationModel
    {
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
    }
}
