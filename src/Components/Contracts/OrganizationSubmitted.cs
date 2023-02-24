namespace Components.Contracts
{
    public record MessageSubmitted
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public DateTime CreatedAtUtc { get; init; }
    }
}
