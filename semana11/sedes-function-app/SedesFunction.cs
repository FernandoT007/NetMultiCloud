using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace SedesFunctionApp
{
    public class SedesFunction
    {
        private readonly ILogger<SedesFunction> _logger;

        public SedesFunction(ILogger<SedesFunction> logger)
        {
            _logger = logger;
        }

        [Function("SedesFunction")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
