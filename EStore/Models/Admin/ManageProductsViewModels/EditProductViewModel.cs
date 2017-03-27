using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace EStore.Models.Admin.ManageProductsViewModels
{
    public class EditProductViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        [Required]
        public bool Public { get; set; }

        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        public IFormFile FileInput { get; set; }

        public IList<Category> Categories { get; set; }

        public const int ImageMinimumBytes = 512;

        public bool IsImage()
        {
            //-------------------------------------------
            //  Check the image mime types
            //-------------------------------------------
            if (FileInput.ContentType.ToLower() != "image/jpg" &&
                        FileInput.ContentType.ToLower() != "image/jpeg" &&
                        FileInput.ContentType.ToLower() != "image/pjpeg" &&
                        FileInput.ContentType.ToLower() != "image/gif" &&
                        FileInput.ContentType.ToLower() != "image/x-png" &&
                        FileInput.ContentType.ToLower() != "image/png")
            {
                return false;
            }

            //-------------------------------------------
            //  Check the image extension
            //-------------------------------------------
            if (Path.GetExtension(FileInput.FileName).ToLower() != ".jpg"
                && Path.GetExtension(FileInput.FileName).ToLower() != ".png"
                && Path.GetExtension(FileInput.FileName).ToLower() != ".gif"
                && Path.GetExtension(FileInput.FileName).ToLower() != ".jpeg")
            {
                return false;
            }

            return true;
        }
    }
}
