using AutoMapper;
using Loan.Application.DTOs;
using Loan.DataAccess.Models;
using Loan.DataAccess.Persistence;
using Loan.DataAccess.Persistence.Repositories;
using Microsoft.AspNetCore.Hosting;

namespace Loan.Application.MimeServer;

public class MediaService : IMediaService
{
    private readonly IAsyncRepository<Media, AppDbContext> _repository;
    private readonly IWebHostEnvironment _environment;

    private readonly IMapper _mapper;

    public MediaService(IAsyncRepository<Media, AppDbContext> repository, IWebHostEnvironment environment,
        IMapper mapper)
    {
        _repository = repository;
        _environment = environment;
        _mapper = mapper;
    }

    public async Task<Guid> UploadFileAsync(MediaDto mediaDto, OwnerType ownerType, Guid ownerId)
    {
        var file = mediaDto.File;

        if (file == null || file.Length == 0)
            throw new ArgumentException("File is empty.");

        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".pdf" };
        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

        if (!allowedExtensions.Contains(extension))
            throw new ArgumentException("Invalid file type.");

        if (file.Length > 10 * 1024 * 1024)
            throw new ArgumentException("File size exceeds limit.");

        var uniqueFileName = $"{Guid.NewGuid()}{extension}";

        var folderName = ownerType.ToString().ToLower();

        var folderPath = Path.Combine("uploads", folderName);

        var uploadsFolder = Path.Combine(_environment.ContentRootPath, folderPath);
        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        await using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        var media = new Media
        {
            OwnerId = ownerId,
            FileName = file.FileName,
            ContentType = file.ContentType,
            FilePath = $"{Path.Combine(folderPath, uniqueFileName)}",
            CreatedDate = DateTime.UtcNow
        };

        media = await _repository.AddAsync(media);

        return media.Id;
    }

    public async Task<MediaDto> GetFileAsync(Guid fileId)
    {
        var file = await _repository.GetAsync(m => m.Id == fileId);

        if (file == null)
            throw new FileNotFoundException("File not found.");

        return _mapper.Map<MediaDto>(file);
    }
}