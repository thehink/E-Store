using EStore.Data;
using EStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Repositories
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Product> Filter(string query, int categoryId)
        {
            return this._context.Where(
                product => product.Public == true &&
                (string.IsNullOrEmpty(query) || product.Name.Contains(query)) &&
                (categoryId == 0 || product.Category.Id == categoryId)
              );
        }

        public override Product Find(int id)
        {
            return this._context.Include("Category").First(p => p.Id == id);
        }

    }
}
