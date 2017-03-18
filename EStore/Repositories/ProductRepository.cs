using EStore.Data;
using EStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void Add(Product product)
        {

        }

        public IEnumerable<Product> GetAll()
        {
            return this._context.Products.ToList();
        }

        public IEnumerable<Product> Filter(string str, int categoryId, decimal maxPrice = 0, decimal minPrice = 0)
        {
            return this._context.Products.ToList();
        }

        public Product Find(int id)
        {
            return new Product();
        }

        public void Remove(int id)
        {

        }

        public void Update(Product product)
        {

        }
    }
}
