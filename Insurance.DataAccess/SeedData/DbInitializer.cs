using Insurance.DataAccess.DbContexts;
using Insurance.Domain.Entities;

namespace Insurance.DataAccess.SeedData;

public static class DbInitializer
{
    public static void Initialize(InsuranceDbContext context)
    {
        context.Database.EnsureCreated();

        // Check if the table is empty
        if (context.Coverages.Any())
        {
            return; // DB has been seeded
        }

        var entities = new List<InsuranceCoverage>()
        {

            new InsuranceCoverage(coverageType: "پوشش جراحی", minAmount: 5000, maxAmount: 500000000, rate: 0.0052),
            new InsuranceCoverage(coverageType: "پوشش دندان پزشکی", minAmount: 4000, maxAmount: 400000000, rate: 0.0042),
            new InsuranceCoverage(coverageType: "پوشش بستری", minAmount: 2000, maxAmount: 200000000, rate: 0.005),
        };

        foreach (var e in entities)
        {
            context.Coverages.Add(e);
        }
        context.SaveChanges();
    }
}
