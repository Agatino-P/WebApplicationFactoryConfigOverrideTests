using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace TestProject1;

public sealed class XunitLogger<T> : ILogger<T>, IDisposable
{
    private readonly ITestOutputHelper output;

    public XunitLogger(ITestOutputHelper output)
    {
        this.output = output;
    }

    ~XunitLogger()
    {
        this.Dispose();
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception, string> formatter)
    {
        this.output.WriteLine(state?.ToString());
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        return this;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}