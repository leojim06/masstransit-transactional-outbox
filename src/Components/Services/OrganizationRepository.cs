using Components.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Components.Services
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly DbSet<Organization> _organization;
        private readonly OrganizationDbContext _dbContext;

        public OrganizationRepository(OrganizationDbContext dbContext)
        {
            _dbContext = dbContext;
            _organization = dbContext.Organization;
        }

        public async Task AddAsync(Organization organization)
        {
            await _organization.AddAsync(organization);
        }
    }
}
