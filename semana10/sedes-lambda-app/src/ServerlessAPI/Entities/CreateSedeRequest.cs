namespace ServerlessAPI.Entities;

public record CreateSedeRequest
(
    string Name,
    string? ImageBase64
);
