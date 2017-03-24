using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Models.OrderViewModels
{
    public class MyOrdersViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
    }
}
