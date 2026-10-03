using SmartFactory.Domain;

namespace SmartFactory.Tests;

public class ProductionTests
{
    [Fact]
    public void CreateProduction_ShouldHavePlannedStatus()
    {
        var production = new Production(1, "Metal Gear", 100);

        Assert.Equal(
            Production.ProductionStatus.Planned,
            production.Status);
    }

    [Fact]
    public void StartProduction_ShouldChangeStatusToInProgress()
    {
        var production = new Production(1, "Metal Gear", 100);

        production.StartProduction();

        Assert.Equal(
            Production.ProductionStatus.InProgress,
            production.Status);
    }

    [Fact]
    public void StartProduction_ShouldSetStartTime()
    {
        var production = new Production(1, "Metal Gear", 100);

        production.StartProduction();

        Assert.NotEqual(default, production.StartTime);
    }

    [Fact]
    public void StartProduction_WhenAlreadyStarted_ShouldThrowException()
    {
        var production = new Production(1, "Metal Gear", 100);

        production.StartProduction();

        Assert.Throws<InvalidOperationException>(
            () => production.StartProduction());
    }

    [Fact]
    public void CompleteProduction_ShouldChangeStatusToCompleted()
    {
        var production = new Production(1, "Metal Gear", 100);

        production.StartProduction();
        production.CompleteProduction();

        Assert.Equal(
            Production.ProductionStatus.Completed,
            production.Status);
    }

    [Fact]
    public void CompleteProduction_ShouldSetEndTime()
    {
        var production = new Production(1, "Metal Gear", 100);

        production.StartProduction();
        production.CompleteProduction();

        Assert.NotNull(production.EndTime);
    }

    [Fact]
    public void CompleteProduction_WhenNotInProgress_ShouldThrowException()
    {
        var production = new Production(1, "Metal Gear", 100);

        Assert.Throws<InvalidOperationException>(
            () => production.CompleteProduction());
    }

    [Fact]
    public void CancelProduction_ShouldChangeStatusToCancelled()
    {
        var production = new Production(1, "Metal Gear", 100);

        production.CancelProduction();

        Assert.Equal(
            Production.ProductionStatus.Cancelled,
            production.Status);
    }

    [Fact]
    public void CancelProduction_ShouldSetEndTime()
    {
        var production = new Production(1, "Metal Gear", 100);

        production.CancelProduction();

        Assert.NotNull(production.EndTime);
    }

    [Fact]
    public void CancelProduction_WhenCompleted_ShouldThrowException()
    {
        var production = new Production(1, "Metal Gear", 100);

        production.StartProduction();
        production.CompleteProduction();

        Assert.Throws<InvalidOperationException>(
            () => production.CancelProduction());
    }
}