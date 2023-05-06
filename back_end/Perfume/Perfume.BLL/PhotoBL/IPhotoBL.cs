using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Perfume.BL
{
    public interface IPhotoBL
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);

        Task<List<ImageUploadResult>> AddMultiplePhotoAsync(IFormFileCollection file);

        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}

