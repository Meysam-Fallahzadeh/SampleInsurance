namespace Insurance.Domain.Entities;

public class InsuranceCoverage
{
    public int Id { get; private set; }
    public string CoverageType { get; private set; }
    public double MinimumAmount { get; private set; }
    public double MaximumAmount { get; private set; }
    public double Rate { get; private set; } 

    public InsuranceCoverage(string coverageType, double minAmount, double maxAmount, double rate)
    {
        CoverageType = coverageType;
        MinimumAmount = minAmount;
        MaximumAmount = maxAmount;
        Rate = rate;
    }

    public InsuranceCoverage()
    {
    }

    public double GetValidAmount(double amount)
    {
        if (amount < MinimumAmount)
            return 0;
        else if (amount > MaximumAmount)
            return MaximumAmount;
        else
            return amount;
    }
}
