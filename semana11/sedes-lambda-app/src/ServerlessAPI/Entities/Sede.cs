using Amazon.DynamoDBv2.DataModel;

namespace ServerlessAPI.Entities;

[DynamoDBTable("Sedes")]
public class Sede
{
    [DynamoDBHashKey]
    public required string Id { get; set; }

    public required string Name { get; set; }

    public string? ImageKey { get; set; }
}