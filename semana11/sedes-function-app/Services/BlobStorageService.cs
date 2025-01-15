using Azure.Storage.Blobs;

namespace sedes_function_app.Services;

public class BlobStorageService
{
    private readonly BlobServiceClient _blobServiceClient;

    public BlobStorageService(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient;
    }

    public async Task<string> UploadImageAsync(string base64Image, string blobName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient("sedes");
        await containerClient.CreateIfNotExistsAsync();

        var blobClient = containerClient.GetBlobClient($"{blobName}.jpg");
        byte[] imageBytes = Convert.FromBase64String(base64Image);

        using (var stream = new MemoryStream(imageBytes))
        {
            await blobClient.UploadAsync(stream, overwrite: true);
        }

        return blobClient.Uri.ToString();
    }
}