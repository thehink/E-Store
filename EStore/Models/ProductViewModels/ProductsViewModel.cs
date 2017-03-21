using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Models.ProductViewModels
{
    public class ProductsViewModel
    {
        public string Query { get; set; }
        public int? CategoryId { get; set; }
        public IList<Product> Products { get; set; }
        public IList<Category> Categories { get; set; }
    }
}
