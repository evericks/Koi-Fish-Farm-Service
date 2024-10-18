using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Evercloud.Services.Interfaces
{
    public interface IEvercloudService
    {
        Task<string?> UploadAsync(IFormFile file, string path);
    }
}
