using EADS.RazorDemo.Data;
using EADS.RazorDemo.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<EADSRazorDemoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EADSRazorDemoContext") ?? throw new InvalidOperationException("Connection string 'EADSRazorDemoContext' not found.")));
builder.Services.AddScoped<IFormFileService, FormFileService>();
builder.Services.AddScoped<IAPIService, APIService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
