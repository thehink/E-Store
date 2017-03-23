using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Models
{
    public class Order
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ModifiedAt { get; set; }

        public virtual ICollection<CartItem> Items { get; set; } = new List<CartItem>();

        public virtual string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public decimal TotalPrice
        {
            get
            {
                return this.Items.Sum(item => item.Count * item.Price);
            }
        }
    }
}
