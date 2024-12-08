using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ApiIenumerableErrors.Tests;

public class ErrorHandlingTests
{
    private WebApplicationFactory<Program> factory;

    [SetUp]
    public void Setup()
    {
        factory = new WebApplicationFactory<Program>();
    }

    [TearDown]
    public void TearDown()
    {
        factory.Dispose();
    }

    [Test]
    public async Task CallUnhandledEndpoint()
    {
        using var httpClient = factory.CreateClient();

        var response = await httpClient.GetAsync("/WeatherForecast/unhandled");

        response.Should().HaveServerError();
        response.Content.Headers.ContentType?.MediaType.Should().Be("text/plain");
    }

    [Test]
    public async Task CallHandledEndpoint()
    {
        using var httpClient = factory.CreateClient();

        var response = await httpClient.GetAsync("/WeatherForecast/handled");

        response.Should().HaveServerError();
        response.Content.Headers.ContentType?.MediaType.Should().Be("application/json");
    }
}
