using Microsoft.AspNetCore.Http;

namespace Loan.Application.DTOs;

public record MediaDto : BaseDto
{
    public Guid OwnerId { get; set; }

    public string FileName { get; set; }

    public string ContentType { get; set; }

    public string FilePath { get; set; }

    public IFormFile File { get; set; }
}