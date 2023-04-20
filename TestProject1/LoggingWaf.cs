using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace TestProject1;
public class LoggingWaf<T> : WebApplicationFactory<T> where T : class
{

    public LoggingWaf()
    {
    }
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration(webBuilder =>
        {
            webBuilder.AddInMemoryCollection(new Dictionary<string, string>()
            {
                {"Store1","Test" },
                {"Store2","Test" }
            });
        });

        //builder.ConfigureLogging(logging=>logging.AddJsonConsole());
        base.ConfigureWebHost(builder);
    }
}
