
using Amazon.S3;
using Amazon.S3.Model;

namespace ServerlessAPI.Services;

public class S3Service : IS3Service
{
    private readonly IAmazonS3 _s3Client;

    public S3Service(IAmazonS3 s3Client)
    {
        _s3Client = s3Client;
    }

    public Task<string> GetPreSignedUrlAsync(string bucketName, string fileKey, TimeSpan expiry)
    {
       var request = new GetPreSignedUrlRequest
       {
           BucketName = bucketName,
           Key = fileKey,
           Expires = DateTime.UtcNow.Add(expiry)
       };

        return Task.FromResult(_s3Client.GetPreSignedURL(request));
    }

    public async Task<string?> UploadFileAsync(string bucketName, string fileKey, Stream fileStream, string contentType)
    {
        var putRequest = new PutObjectRequest
        {
            BucketName = bucketName,
            Key = fileKey,
            InputStream = fileStream,
            ContentType = contentType
        };

        await _s3Client.PutObjectAsync(putRequest);

        return fileKey;
    }
}