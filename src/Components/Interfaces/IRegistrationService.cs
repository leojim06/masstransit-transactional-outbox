namespace Components.Interfaces
{
    public interface IRegistrationService
    {
        Task<Organization> Send(string name, string description);
    }
}
