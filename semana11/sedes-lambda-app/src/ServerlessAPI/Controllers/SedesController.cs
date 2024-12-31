using Microsoft.AspNetCore.Mvc;
using ServerlessAPI.Entities;
using ServerlessAPI.Repositories;
using ServerlessAPI.Services;

namespace ServerlessAPI.Controllers;

[Route("api/[controller]")]
[Produces("application/json")]
public class SedesController : ControllerBase
{
    private readonly ISedeRepository _sedeRepository;
    private readonly IS3Service _s3Service;
    private readonly IEmailService _emailService;
    private readonly IConfiguration _configuration;

    public SedesController(ISedeRepository sedeRepository, IS3Service s3Service, IEmailService emailService, IConfiguration configuration)
    {
        _sedeRepository = sedeRepository;
        _s3Service = s3Service;
        _emailService = emailService;
        _configuration = configuration;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSede([FromBody] CreateSedeRequest request)
    {
        var sedeId = Guid.NewGuid().ToString();

        string? imageKey = null;
        if (!string.IsNullOrWhiteSpace(request.ImageBase64))
        {
            var imageBytes = Convert.FromBase64String(request.ImageBase64);
            using var stream = new MemoryStream(imageBytes);
            imageKey = await _s3Service.UploadFileAsync(
                _configuration["AWS:BucketName"]!,
                $"{sedeId}.jpg",
                stream,
                "image/jpeg");
        }

        var sede = new Sede { Id = sedeId, Name = request.Name, ImageKey = imageKey };
        await _sedeRepository.CreateAsync(sede);

        await _emailService.SendEmailAsync(
            _configuration["AWS:SES:Source"]!,
            _configuration["AWS:SES:Destination"]!,
            $"Nueva sede creada: {sede.Name}",
            $"Se ha creado una nueva sede con el nombre {request.Name}");

        return CreatedAtAction(nameof(GetSede), new { id = sede.Id }, sede);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSede(string id)
    {
        var sede = await _sedeRepository.GetByIdAsync(id);
        if (sede == null) return NotFound();

        string? imageUrl = null;
        if (!string.IsNullOrWhiteSpace(sede.ImageKey))
        {
            imageUrl = await _s3Service.GetPreSignedUrlAsync(
                _configuration["AWS:BucketName"]!,
                sede.ImageKey,
                TimeSpan.FromMinutes(5));
        }

        return Ok(new { sede.Id, sede.Name, ImageUrl = imageUrl });
    }

}