using Mapster;
using RichDomainModel.Application;
using RichDomainModel.Infrastructure;
using RichDomainModel.Rich.Aggregates.TimeEntry;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
    
    // TODO: Create generic solution
    TypeAdapterConfig.GlobalSettings.ForType<TimeEntryId, Guid>()
        .MapWith(src => src.Value);

    TypeAdapterConfig.GlobalSettings.ForType<Guid, TimeEntryId>()
        .MapWith(src => new TimeEntryId(src));
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.UseCors("origin");
    app.UseExceptionHandler("/error");
    
    app.Run();
}
