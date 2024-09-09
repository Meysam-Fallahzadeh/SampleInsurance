using Insurance.Domain.Entities;

namespace Insurance.XUnitTest.Domain.Entities;


public class InsuranceCoverageDemandTests
{
    [Fact]
    public void CalculatePremium_ValidAmount_ReturnsExpectedPremium()
    {
        // Arrange
        var insuranceCoverage = new InsuranceCoverage("Health", 1000, 10000, 0.05);

        var request = new InsuranceCoverageDemand(insuranceCoverage, 5000);

        // Act
        var result = request.CalculatePremium();

        // Assert
        Assert.Equal(250, result); // 5000 * 0.05 = 250
    }

    [Fact]
    public void CalculatePremium_AmountLessThanMinimum_ReturnsZeroPremium()
    {
        // Arrange
        var insuranceCoverage = new InsuranceCoverage("Health", 1000, 10000, 0.05);

        var request = new InsuranceCoverageDemand(insuranceCoverage, 500);

        // Act
        var result = request.CalculatePremium();

        // Assert
        Assert.Equal(0, result); // 0 * 0.05 = 0
    }

    [Fact]
    public void CalculatePremium_AmountGreaterThanMaximum_ReturnsMaximumPremium()
    {
        // Arrange
        var insuranceCoverage = new InsuranceCoverage("Health", 1000, 10000, 0.05);

        var request = new InsuranceCoverageDemand(insuranceCoverage, 500000);

        // Act
        var result = request.CalculatePremium();

        // Assert
        Assert.Equal(500, result); // 10000 * 0.05 = 500
    }
}
