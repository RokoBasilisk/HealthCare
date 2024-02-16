using Auth.API.Extensions;
using Auth.API.Middlewares;
using Auth.Application;
using Auth.Infrastructure;
using Core.Extensions;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .ConfigureAppSettings()
    .AddWriteDbContext()
    //.AddEventStoreDbContext()
    .AddInfrastructure()
    .AddCommandHandler();

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

app.UseErrorHandling();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await using var serviceScope = app.Services.CreateAsyncScope();

app.Logger.LogInformation("----- Databases are being migrated....");
await app.MigrationDbAsync(serviceScope);

app.Logger.LogInformation("----- Databases have been successfully migrated!");
app.Logger.LogInformation("----- Application is starting....");

await app.RunAsync();
