using Insurance.Domain.Entities;

namespace Insurance.Domain.RepositoriesInterface;

public interface IInsuranceDemandRepository
{
    Task<InsuranceDemand> GetByIdAsync(int id);
    Task<IEnumerable<InsuranceDemand>> GetAllAsync();
    Task AddAsync(InsuranceDemand request);
    Task SaveChangesAsync();
}