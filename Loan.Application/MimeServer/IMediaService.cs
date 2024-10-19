using Loan.Application.DTOs;
using Loan.DataAccess.Models;
using Microsoft.AspNetCore.Http;

namespace Loan.Application.MimeServer;

public interface IMediaService
{
    Task<Guid> UploadFileAsync(MediaDto media, OwnerType ownerType, Guid ownerId);
    Task<MediaDto> GetFileAsync(Guid fileId);
}