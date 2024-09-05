
using DotNetEnv;
using MSRosaAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace MSRosaAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        Env.Load();
        var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
        var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
        var dbDatabaseName = Environment.GetEnvironmentVariable("DB_DATABASE");
        var dbUser = Environment.GetEnvironmentVariable("DB_USERNAME");
        var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
        var conectionDB = $"server={dbHost};port={dbPort};database={dbDatabaseName};uid={dbUser};password={dbPassword}";
        builder.Services.AddDbContext<productosDbContext>(options => options.UseMySql(conectionDB, ServerVersion.Parse("8.0.20-mysql")));

        var mpdbHost = Environment.GetEnvironmentVariable("DB_HOST");
        var mpdbPort = Environment.GetEnvironmentVariable("DB_PORT");
        var mpdbDatabaseName = Environment.GetEnvironmentVariable("DB_DATABASE");
        var mpdbUser = Environment.GetEnvironmentVariable("DB_USERNAME");
        var mpdbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

        var mpconectionDB = $"server={mpdbHost};port={mpdbPort};database={mpdbDatabaseName};uid={mpdbUser};password={mpdbPassword}";
        builder.Services.AddDbContext<DeudoresDbContext>(options => options.UseMySql(conectionDB, ServerVersion.Parse("8.0.20-mysql")));




        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

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
