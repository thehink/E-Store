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

        public int Limit { get; set; }

        public int Page { get; set; }

        public int Results { get; set; }

        public int Pages => (int)Math.Ceiling((decimal)((decimal)Results / (decimal)Limit));

        public string GetActivePageClass(int page)
        {
            return this.Page == page ? "active" : "";
        }
    }
}
