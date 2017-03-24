using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Models
{
    public class Order
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

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
