using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Models.Admin.ManageOrdersViewModels
{
    public class OrderStatusViewModel
    {
        public string Id { get; set; }

        public OrderStatus Status { get; set; }
        
    }
}
