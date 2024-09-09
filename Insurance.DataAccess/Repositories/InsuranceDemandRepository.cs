using Insurance.DataAccess.DbContexts;
using Insurance.Domain.Entities;
using Insurance.Domain.RepositoriesInterface;
using Microsoft.EntityFrameworkCore;

namespace Insurance.DataAccess.Repositories;

public class InsuranceDemandRepository : IInsuranceDemandRepository
{
    private readonly InsuranceDbContext _context;

    public InsuranceDemandRepository(InsuranceDbContext context)
    {
        _context = context;
    }

    public async Task<InsuranceDemand> GetByIdAsync(int id)
    {
        return await _context.Demands.Include(r => r.Coverages).ThenInclude(c => c.Coverage).FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<IEnumerable<InsuranceDemand>> GetAllAsync()
    {
        return await _context.Demands.Include(r => r.Coverages).ThenInclude(c => c.Coverage).ToListAsync();
    }

    public async Task AddAsync(InsuranceDemand request)
    {
        await _context.Demands.AddAsync(request);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}