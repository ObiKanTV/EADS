using EADS.Application.Services;
using EADS.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EADSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EADSContext") ?? throw new InvalidOperationException("Connection string 'EADSContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IEncryptionService, EncryptionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
