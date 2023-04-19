using Microsoft.Extensions.Configuration;

namespace WebApplicationFactoryConfigOverrideTests;

public partial  class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSingleton<Store1>(new Store1(builder.Configuration["Store1"]));
        string s2 = builder.Configuration["Store2"];
        builder.Services.AddScoped<Store2>((services)=>new Store2(s2));
        builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
public record Store1(string store);
public record Store2(string store);