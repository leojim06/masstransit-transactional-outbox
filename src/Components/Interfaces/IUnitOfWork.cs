namespace Components.Interfaces
{
    public interface IUnitOfWork
    {
        IOrganizationRepository OrganizationRepository { get; }
        Task SaveChangesAsync();
    }
}
