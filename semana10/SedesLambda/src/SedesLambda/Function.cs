using System.Text.Json;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace SedesLambda;

public class Function
{
    private readonly IAmazonDynamoDB _amazonDynamoDB;

    public Function()
    {
        _amazonDynamoDB = new AmazonDynamoDBClient();
    }


    public async Task<APIGatewayProxyResponse> FunctionHandler(
        APIGatewayProxyRequest request
        , ILambdaContext context)
    {
        context.Logger.LogLine("Request: " + request.Body);

        var inputData = JsonSerializer.Deserialize<Sede>(request.Body);

        var requestDynamoDb = new PutItemRequest
        {
            TableName = "Sedes",
            Item = new Dictionary<string, AttributeValue>
            {
                {"Id", new AttributeValue {S = inputData!.Id}},
                {"Name", new AttributeValue {S = inputData.Name}}
            }
        };

        await _amazonDynamoDB.PutItemAsync(requestDynamoDb);

        return new APIGatewayProxyResponse 
        {
            StatusCode = 200,
            Body = "Sede creada",
            Headers = new Dictionary<string, string> { { "Content-Type", "text/json" } }
        };

    }

    public record Sede(string Id, string Name);
}
