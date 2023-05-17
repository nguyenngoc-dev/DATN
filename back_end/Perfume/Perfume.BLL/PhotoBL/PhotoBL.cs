﻿using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Perfume.BL;

namespace Perfume.BL
{
    public class PhotoBL : IPhotoBL
    {
        private readonly Cloudinary _cloudinary;

        public PhotoBL(IOptions<CloudinarySettings> config)
        {
            var acc = new Account
            (
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);
        }

        public async Task<List<ImageUploadResult>> AddMultiplePhotoAsync(IFormFileCollection files)
        {
            List<ImageUploadResult> result = new();
            if (files.Count > 0)
            {
                var uploadResult = new ImageUploadResult();

                var length = files.Count;
                for (int i = 0; i < length; i++)
                {
                    if (files[i].Length > 0)
                    {
                        await using var stream = files[i].OpenReadStream();
                        var uploadParams = new ImageUploadParams
                        {
                            File = new FileDescription(files[i].FileName, stream),
                            Transformation = new Transformation()
                        };

                        uploadResult = await _cloudinary.UploadAsync(uploadParams);
                    }

                    result.Add(uploadResult);
                }
            }


            return result;
        }

        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                await using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill")
                };

                uploadResult = await _cloudinary.UploadAsync(uploadParams);


            }

            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);

            var result = await _cloudinary.DestroyAsync(deleteParams);

            return result;
        }

    }
}
