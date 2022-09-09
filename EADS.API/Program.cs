using EADS.Application.Services;
using EADS.Application.Services.Repositories;
using EADS.Domain.Interfaces.Repositories;
using EADS.Domain.Interfaces.Services;
using EADS.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EADSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EADSContext") ?? throw new InvalidOperationException("Connection string 'EADSContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IEncryptionService, EncryptionService>();
builder.Services.AddScoped<IDemoPresentationEncRepository, DemoPresentationEncRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
