using Loan.Application.DTOs;
using Microsoft.AspNetCore.Http;

namespace Loan.Application.MimeServer;

public interface IMediaService
{
    Task<Guid> UploadFileAsync(MediaDto media, Guid ownerId);
    Task<MediaDto> GetFileAsync(Guid fileId);
}