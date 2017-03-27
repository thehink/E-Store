using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace EStore.Utils
{
    public static class SaveImageHelper
    {
        public static async Task<string> SaveImage(IFormFile FileInput, string uploads)
        {
            string imagePath = "";
            string pubImagePath = "";

            using (var md5 = MD5.Create())
            {
                using (var stream = FileInput.OpenReadStream())
                {
                    var hash = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
                    var imageName = hash + Path.GetExtension(FileInput.FileName).ToLower();
                    imagePath = Path.Combine(uploads, imageName);
                    pubImagePath = $"/uploads/{imageName}";
                }
            }

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await FileInput.CopyToAsync(fileStream);
            }

            return pubImagePath;
        }
    }
}
