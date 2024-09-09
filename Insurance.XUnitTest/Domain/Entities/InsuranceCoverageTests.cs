namespace Insurance.XUnitTest.Domain.Entities;

using Insurance.Domain.Entities;
using Xunit;

public class InsuranceCoverageTests
{
    [Fact]
    public void GetValidAmount_AmountLessThanMinimum_ReturnsZero()
    {
        // Arrange
        var insuranceCoverage = new InsuranceCoverage("Health", 1000, 10000, 0.05);

        // Act
        var result = insuranceCoverage.GetValidAmount(500);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GetValidAmount_AmountGreaterThanMaximum_ReturnsMaximumAmount()
    {
        // Arrange
        var insuranceCoverage = new InsuranceCoverage("Health", 1000, 10000, 0.05);

        // Act
        var result = insuranceCoverage.GetValidAmount(15000);

        // Assert
        Assert.Equal(10000, result);
    }

    [Fact]
    public void GetValidAmount_AmountWithinRange_ReturnsAmount()
    {
        // Arrange
        var insuranceCoverage = new InsuranceCoverage("Health", 1000, 10000, 0.05);

        // Act
        var result = insuranceCoverage.GetValidAmount(5000);

        // Assert
        Assert.Equal(5000, result);
    }
}

