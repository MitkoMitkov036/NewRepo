using Moq;
using WatchService.BL.Services;
using WatchService.DL.Interfaces;
using WatchService.Models.Entities;
using Xunit;

namespace WatchService.Tests;

public class SellWatchServiceTests
{
    [Fact]
    public async Task SellAsync_ShouldReturnSuccess_WhenWatchAndCustomerExistAndStockIsAvailable()
    {
        // Arrange
        var watchId = "watch1";
        var customerId = "customer1";

        var watch = new Watch
        {
            Id = watchId,
            Brand = "Seiko",
            Model = "Presage",
            Price = 1000,
            Type = "Mechanical",
            StockQuantity = 5
        };

        var customer = new Customer
        {
            Id = customerId,
            FirstName = "Mitko",
            LastName = "Mitkov",
            Email = "mitkotest@gmail.com"
        };

        var watchRepoMock = new Mock<IWatchRepository>();
        var customerRepoMock = new Mock<ICustomerRepository>();

        watchRepoMock.Setup(r => r.GetByIdAsync(watchId))
            .ReturnsAsync(watch);

        customerRepoMock.Setup(r => r.GetByIdAsync(customerId))
            .ReturnsAsync(customer);

        watchRepoMock.Setup(r => r.UpdateAsync(It.IsAny<Watch>()))
            .Returns(Task.CompletedTask);

        var service = new SellWatchService(
            watchRepoMock.Object,
            customerRepoMock.Object);

        // Act
        var result = await service.SellAsync(watchId, customerId);

        // Assert
        Assert.True(result.IsSuccessful);
        Assert.Equal("Watch sold successfully", result.Message);
    }

    [Fact]
    public async Task SellAsync_ShouldReturnFailure_WhenWatchIsOutOfStock()
    {
        // Arrange
        var watchId = "watch1";
        var customerId = "customer1";

        var watch = new Watch
        {
            Id = watchId,
            Brand = "Seiko",
            Model = "Presage",
            Price = 1000,
            Type = "Mechanical",
            StockQuantity = 0
        };

        var watchRepoMock = new Mock<IWatchRepository>();
        var customerRepoMock = new Mock<ICustomerRepository>();

        watchRepoMock.Setup(r => r.GetByIdAsync(watchId))
            .ReturnsAsync(watch);

        var service = new SellWatchService(
            watchRepoMock.Object,
            customerRepoMock.Object);

        // Act
        var result = await service.SellAsync(watchId, customerId);

        // Assert
        Assert.False(result.IsSuccessful);
        Assert.Equal("Watch is out of stock", result.Message);
    }
}
