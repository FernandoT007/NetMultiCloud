using Docentes.Api.Extensions;
using Docentes.Application;
using Docentes.Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( options =>
    {
       options.SwaggerDoc("v1", new OpenApiInfo {
            Version = "v1",
            Title = "Docentes Api",
            Description = "Api para la gestión de docentes",
            Contact = new OpenApiContact {
                Name = "Fernando Tanta",
                Email = "fernando.tanta@correo.com"
            }
       });
    }
);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ApplyMigrations();

app.UseCustomExceptionHandler();

app.MapControllers();

app.Run();
