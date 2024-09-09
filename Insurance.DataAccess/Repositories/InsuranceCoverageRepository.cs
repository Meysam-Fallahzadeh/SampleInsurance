using Insurance.DataAccess.DbContexts;
using Insurance.Domain.Entities;
using Insurance.Domain.RepositoriesInterface;
using Microsoft.EntityFrameworkCore;

namespace Insurance.DataAccess.Repositories;

public class InsuranceCoverageRepository : IInsuranceCoverageRepository
{
    private readonly InsuranceDbContext _context;

    public InsuranceCoverageRepository(InsuranceDbContext context)
    {
        _context = context;
    }

    public async Task<InsuranceCoverage> GetByIdAsync(int id)
    {
        return await _context.Coverages.Where(c => c.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<InsuranceCoverage>> GetAllAsync()
    {
        return await _context.Coverages.ToListAsync();
    }

    public async Task AddAsync(InsuranceCoverage request)
    {
        await _context.Coverages.AddAsync(request);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}