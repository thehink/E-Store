using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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

        [Required]
        public bool Public { get; set; }

        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        public IList<Category> Categories { get; set; }
    }
}
