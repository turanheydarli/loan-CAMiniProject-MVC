using Loan.Application.MimeServer;
using Microsoft.AspNetCore.Mvc;

namespace Loan.WebMVC.Controllers;

public class MediaController : Controller
{
    private readonly IMediaService _mediaService;
    private readonly IWebHostEnvironment _environment;

    public MediaController(IMediaService mediaService, IWebHostEnvironment environment)
    {
        _mediaService = mediaService;
        _environment = environment;
    }

    [HttpGet("[controller]/[action]/{fileId}")]
    public async Task<IActionResult> GetImage(Guid fileId)
    {
        var file = await _mediaService.GetFileAsync(fileId);

        if (!file.ContentType.StartsWith("image/"))
            return BadRequest("Invalid image file.");

        var filePath = Path.Combine(_environment.ContentRootPath, file.FilePath.TrimStart('/'));

        if (!System.IO.File.Exists(filePath))
            return NotFound("File not found.");

        var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        return File(fileStream, file.ContentType);
    }

    [HttpGet("[controller]/[action]/{fileId}")]
    public async Task<IActionResult> GetDocument(Guid fileId)
    {
        var file = await _mediaService.GetFileAsync(fileId);

        if (file.ContentType != "application/pdf")
            return BadRequest("Invalid document file.");

        var filePath = Path.Combine(_environment.ContentRootPath, file.FilePath.TrimStart('/'));

        if (!System.IO.File.Exists(filePath))
            return NotFound("File not found.");

        var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        return File(fileStream, file.ContentType);
    }
}