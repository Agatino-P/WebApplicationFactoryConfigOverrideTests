using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
using WebApplicationFactoryConfigOverrideTests;

namespace TestProject1;

public class MyWebFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration((_, builder) =>
        {
            builder.AddInMemoryCollection(new Dictionary<string, string>()
            {
                {"Store1","Test" },
                {"Store2","Test" }
            });
        }
        );

        base.ConfigureWebHost(builder);
    }
}
