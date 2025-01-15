using Azure.Storage.Blobs;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using sedes_function_app.Persistence;
using sedes_function_app.Services;

var builder = FunctionsApplication.CreateBuilder(args);

// Configurar DbContext
builder.Services.AddDbContext<SedeDbContext>(options =>
{
    var connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException("La cadena de conexión 'SqlConnectionString' no está configurada.");
    }
    options.UseSqlServer(connectionString);
});

// Configurar BlobStorageService
builder.Services.AddSingleton(x =>
{
    var blobConnectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
    if (string.IsNullOrEmpty(blobConnectionString))
    {
        throw new InvalidOperationException("La cadena de conexión 'AzureWebJobsStorage' no está configurada.");
    }
    return new BlobServiceClient(blobConnectionString);
});

// Registrar servicios
builder.Services.AddScoped<BlobStorageService>();
builder.Services.AddScoped<SedeService>();

// Ejecutar la aplicación

builder.Build().Run();
