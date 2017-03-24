using System;
using System.ComponentModel.DataAnnotations;

namespace EStore.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        public int Count { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; }
  
        public string CartId { get; set; }
        public virtual Cart Cart { get; set; }

        public virtual Product Product { get; set; }
    }
}
