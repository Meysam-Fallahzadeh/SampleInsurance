namespace Insurance.Domain.Entities;

public class InsuranceCoverageDemand
{
    public int Id { get; private set; }
    public InsuranceCoverage Coverage { get; private set; }
    public double Amount { get; private set; }

    public InsuranceCoverageDemand(InsuranceCoverage coverage, double amount)
    {
        Coverage = coverage;
        Amount = amount;
    }
    public InsuranceCoverageDemand()
    {
    }

    public double CalculatePremium()
    {
        var validAmount = Coverage.GetValidAmount(Amount);

        return validAmount * Coverage.Rate;
    }
}