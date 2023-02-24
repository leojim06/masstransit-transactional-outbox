namespace Components.Interfaces
{
    public interface IOrganizationRepository
    {
        Task AddAsync(Organization organization);
    }
}
