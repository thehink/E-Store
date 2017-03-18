using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EStore.Models
{
    public class Product
    {

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public bool Public { get; set; }

        public virtual Category Category { get; set; }
    }
}
