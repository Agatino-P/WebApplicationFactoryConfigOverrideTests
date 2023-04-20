using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using WebApplicationFactoryConfigOverrideTests;
using Xunit.Abstractions;

namespace TestProject1;

public class UnitTest2 : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _webFactory;
    private readonly ITestOutputHelper _output;

    public UnitTest2(WebApplicationFactory<Program> _webFactory, ITestOutputHelper output)
    {
        _output = output;
        this._webFactory = _webFactory.WithTestLogging(_output);
    }
    [Fact]
    public async Task Test2Async()
    {

        var c = _webFactory.CreateClient(/*new WebApplicationFactoryClientOptions { AllowAutoRedirect = false }*/);
        var r = await c.GetAsync("/weatherforecast");
        var s = await r.Content.ReadAsStringAsync();
        Assert.True(s == "Test");
    }
}