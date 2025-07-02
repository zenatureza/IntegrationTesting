using Xunit;

namespace Customers.Api.Tests.Integration;

public class CustomerControllerTests
{
    [Fact]
    public async Task Get_ReturnsNotFound_WhenCustomerDoesNotExist()
    {
        // Arrange
        var customerId = Guid.NewGuid();
        
        // Act
        var response = await new HttpClient
        {
            BaseAddress = new Uri("https://localhost:5001")
        }.GetAsync($"customers/{customerId}");

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
    }
}
