using System.Collections;
using Xunit;

namespace Customers.Api.Tests.Integration;

public class CustomerControllerTests
{
    [Theory]
    [ClassData(typeof(ClassData))]
    public async Task Get_ReturnsNotFound_WhenCustomerDoesNotExist(string guidAsText)
    {
        // Arrange
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:5001")
        };

        // Act
        var response = await httpClient.GetAsync($"customers/{guidAsText}");

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
    }
}

public class ClassData : IEnumerable<object>
{
    public IEnumerator<object> GetEnumerator()
    {
        yield return new object[]
        {
            "D160107B-18B9-486A-AC34-12E3BD544655",
            "0E7A33B8-1076-4C91-A83C-EE406C5103D5"
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
