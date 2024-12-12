using Cursos.Api.Extensions;
using Cursos.Api.gRPC;
using Cursos.Application;
using Cursos.Infrastructure;
using Microsoft.AspNetCore.Server.Kestrel.Core;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGrpc();
builder.WebHost.ConfigureKestrel( options =>
{
    options.ListenLocalhost(9999, o => o.Protocols = HttpProtocols.Http1); // rest
    options.ListenLocalhost(5001, o => o.Protocols = HttpProtocols.Http2); // grpc
});

builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddInfraestructure(builder.Configuration);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionHandler();
app.MapControllers();
app.MapGrpcService<CursosGrpcService>();

app.Run();
