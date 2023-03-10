using SamStore.Catalog.API.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using SamStore.Catalog.API.Domain.Interfaces;
using SamStore.Catalog.API.Data.Repositories;
using SamStore.WebAPI.Core.API.Configurations;
using SamStore.WebAPI.Core.Identity;
using SamStore.Catalog.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencyInjectionConfiguration(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration("Api Catalog");
builder.Services.AddJwtConfiguration(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", config =>
    {
        config.WithOrigins("http://localhost", "http://localhost:4200");
        config.AllowAnyMethod();
        config.AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
