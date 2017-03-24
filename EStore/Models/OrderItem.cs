using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int Count { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; }

        public string OrderId { get; set; }
        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
