using Microsoft.EntityFrameworkCore;
using Practice.Application.Extensions;
using Practice.Infrastructure.Configuration;
using Practice.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.ConfigureDatabase(builder.Configuration)
    .ConfigureApplication();

builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PracticeDbContext>();
    db.Database.Migrate();
}

app.MapControllers();
app.Run();