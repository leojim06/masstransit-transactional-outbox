using Components.Interfaces;
using Microsoft.Extensions.Logging;

namespace Components.Services
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly OrganizationDbContext _dbContext;
        private readonly ILogger<UnitOfWork> _logger;

        public UnitOfWork(OrganizationDbContext dbContext, 
            ILogger<UnitOfWork> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
            OrganizationRepository = new OrganizationRepository(dbContext);
        }

        public IOrganizationRepository OrganizationRepository { get; private set; }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
