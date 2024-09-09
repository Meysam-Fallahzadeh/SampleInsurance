namespace Insurance.Domain.Entities;

public class InsuranceDemand
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public List<InsuranceCoverageDemand> Coverages { get; private set; }
    public double TotalPremium { get; private set; } 

    public InsuranceDemand(string title)
    {
        Title = title;
        Coverages = new List<InsuranceCoverageDemand>();
    }

    public InsuranceDemand()
    {
        
    }
    public void AddCoverage(InsuranceCoverage coverage, double amount)
    {
        var coverageDemand = new InsuranceCoverageDemand(coverage, amount);

        Coverages.Add(coverageDemand);

        TotalPremium += coverageDemand.CalculatePremium();
    }

}