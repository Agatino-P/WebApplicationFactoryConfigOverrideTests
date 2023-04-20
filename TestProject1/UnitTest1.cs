using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using WebApplicationFactoryConfigOverrideTests;
using Xunit.Abstractions;

namespace TestProject1;

public class UnitTest1 : IClassFixture<MyWebFactory>
{
    private readonly MyWebFactory _webFactory;
    private readonly ITestOutputHelper _output;

    public UnitTest1(MyWebFactory webFactory, ITestOutputHelper output)
    {
        _webFactory = webFactory;
        _output = output;
    }
  //  [Fact]
    public async Task Test1Async()
    {
        var wa2 = new WebApplicationFactory<Program>().WithTestLogging(_output);

        var c = wa2.CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });
        var r = await c.GetAsync("https://localhost/weatherforecast");
        var s = await r.Content.ReadAsStringAsync();
        Assert.True(s == "Test");
    }
}