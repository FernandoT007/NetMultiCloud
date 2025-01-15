using sedes_function_app.Models;
using sedes_function_app.Persistence;

namespace sedes_function_app.Services;

public class SedeService
{
    private readonly SedeDbContext _dbContext;
    private readonly BlobStorageService _blobStorageService;

    public SedeService(SedeDbContext dbContext, BlobStorageService blobStorageService)
    {
        _dbContext = dbContext;
        _blobStorageService = blobStorageService;
    }

    public async Task<Sede> RegistrarSedeAsync(SedeRequest request)
    {
        var imageUrl = await _blobStorageService.UploadImageAsync(request.ImagenBase64, request.NombreSede);

        var sede = new Sede
        {
            Id = Guid.NewGuid(),
            NombreSede = request.NombreSede,
            ImagenUrl = imageUrl
        };

        _dbContext.Sedes!.Add(sede);
        await _dbContext.SaveChangesAsync();

        return sede;
    }

    public async Task<Sede?> GetSedeByIdAsync(Guid id)
    {
        return await _dbContext.Sedes!.FindAsync(id);
    }
}