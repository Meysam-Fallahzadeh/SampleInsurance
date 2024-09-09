using Insurance.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Insurance.DataAccess.DbContexts;

public class InsuranceDbContext : DbContext
{
    public DbSet<InsuranceCoverage> Coverages { get; set; }
    public DbSet<InsuranceDemand> Demands { get; set; }

    public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


    }

}
