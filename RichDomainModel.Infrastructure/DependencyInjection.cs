using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RichDomainModel.Application.Seedwork.Repositories;
using RichDomainModel.Application.Seedwork.Repositories.Seedwork;
using RichDomainModel.Infrastructure.Repositories.Seedwork;
using RichDomainModel.Infrastructure.Repositories.TimeEntry;

namespace RichDomainModel.Infrastructure;

public static class DependencyInjection
{
    private const string ConnectionStringName = "DefaultConnection";
    
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager builderConfiguration)
    {
        services.AddPersistence(builderConfiguration);

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionStringName)
            ?? throw new InvalidOperationException($"Connection string: {ConnectionStringName} not found");

        services.AddDbContext<AppDbContext>(o => o.UseNpgsql(connectionString));

        services.AddScoped<IAppDbContext>(sp => sp.GetRequiredService<AppDbContext>());

        services.AddRepositories();
        
        var databaseSettings = new DatabaseSettings();
        configuration.Bind(DatabaseSettings.SectionName, databaseSettings);

        if (databaseSettings.RecreateOnStartup)
        {
            using var scope = services.BuildServiceProvider().CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            dbContext.Database.Migrate();
        }

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IQueryRepository, QueryRepository>();
        services.AddScoped<ICommandRepository, CommandRepository>();
        services.AddScoped<ITimeEntryRepository, TimeEntryRepository>();
        services.AddScoped<ITagRepository, TagRepository>();

        return services;
    }
}