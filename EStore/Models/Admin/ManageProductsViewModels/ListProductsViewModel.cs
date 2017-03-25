using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Models.Admin.ManageProductsViewModels
{
    public class ListProductsViewModel
    {
        public IList<Product> Products { get; set; }
    }
}
