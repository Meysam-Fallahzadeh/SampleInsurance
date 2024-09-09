using Insurance.Domain.Entities;

namespace Insurance.Domain.RepositoriesInterface
{
    public interface IInsuranceCoverageRepository
    {
        public Task<InsuranceCoverage> GetByIdAsync(int id);

        public Task<IEnumerable<InsuranceCoverage>> GetAllAsync();

        public Task AddAsync(InsuranceCoverage request);

        public Task SaveChangesAsync();
    }
}