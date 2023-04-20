using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using WebApplicationFactoryConfigOverrideTests;
using Xunit.Abstractions;

namespace TestProject1;

public class UnitTest3 : IClassFixture<LoggingWaf<Program>>
{
    private readonly WebApplicationFactory<Program> _webFactory;
    private readonly ITestOutputHelper _output;

    public UnitTest3(LoggingWaf<Program> _webFactory, ITestOutputHelper output)
    {
        this._webFactory = _webFactory.WithTestLogging(output);
        _output = output;

        WebApplicationFactory<Program> w = new WebApplicationFactory<Program>();
        WebApplicationFactory<Program> ww = w.WithWebHostBuilder(c => c.CaptureStartupErrors(false));
    }
    [Fact]
    public async Task Test3Async()
    {

        var c = _webFactory.CreateDefaultClient(/*new WebApplicationFactoryClientOptions { AllowAutoRedirect = false }*/);
        var r = await c.GetAsync("/weatherforecast");
        var s = await r.Content.ReadAsStringAsync();
        Assert.True(s == "Test");
    }
}