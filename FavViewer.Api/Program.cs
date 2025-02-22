using FavViewer.Api.Database;
using FavViewer.Api.Repos;
using FavViewer.Api.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FavViewerDbContext>(opts =>
{
    if (!opts.IsConfigured)
    {
        opts.UseSqlite("Data Source=liens.db");
    }
});

builder.Services.AddScoped<ILienVideoRepo, LienVideoRepo>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
