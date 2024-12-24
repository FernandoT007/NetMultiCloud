using System.Text.Json;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.S3;
using Amazon.SimpleEmail;
using ServerlessAPI.Repositories;
using ServerlessAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuración de archivos por ambiente
builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

//Logger
builder.Logging
        .ClearProviders()
        .AddJsonConsole();
 
// Configuración de servicios en el contenedor
builder.Services
        .AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        });

// Obtener configuración de región
string region = Environment.GetEnvironmentVariable("AWS_REGION") ?? RegionEndpoint.USEast2.SystemName;


// Configuración para DynamoDB (producción o local)
string? dynamoDbLocalUrl = builder.Configuration["AWS:DynamoDBLocalUrl"];
builder.Services.AddSingleton<IAmazonDynamoDB>(provider =>
{
    return !string.IsNullOrEmpty(dynamoDbLocalUrl)
        ? new AmazonDynamoDBClient(new AmazonDynamoDBConfig { ServiceURL = dynamoDbLocalUrl })
        : new AmazonDynamoDBClient(RegionEndpoint.GetBySystemName(region));
});
builder.Services.AddScoped<IDynamoDBContext, DynamoDBContext>();

// Configuración para S3 (producción o MinIO local)
var s3LocalConfig = builder.Configuration.GetSection("AWS:S3Local");
if (!string.IsNullOrEmpty(s3LocalConfig["ServiceUrl"]))
{
    builder.Services.AddSingleton<IAmazonS3>(new AmazonS3Client(
        s3LocalConfig["AccessKey"],
        s3LocalConfig["SecretKey"],
        new AmazonS3Config
        {
            ServiceURL = s3LocalConfig["ServiceUrl"]
        }));
}
else
{
    builder.Services.AddSingleton<IAmazonS3>(new AmazonS3Client(RegionEndpoint.GetBySystemName(region)));
}

// Configuración para SES
builder.Services.AddSingleton<IAmazonSimpleEmailService>(
    new AmazonSimpleEmailServiceClient(RegionEndpoint.GetBySystemName(region))
);

// Habilitar soporte para AWS Lambda (API Gateway)
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

// Repositorios
builder.Services.AddScoped<ISedeRepository, SedeRepository>();
builder.Services.AddScoped<IS3Service, S3Service>();
builder.Services.AddScoped<IEmailService, EmailService>();

// Construcción de la aplicación
var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();

// Endpoints
app.MapControllers();
app.MapGet("/", () => "Welcome to running ASP.NET Core Minimal API on AWS Lambda");

// Iniciar la aplicación
app.Run();
