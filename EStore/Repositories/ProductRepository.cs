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
            this._context.Products.Add(product);
            this._context.SaveChanges();
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
            return this._context.Products.FirstOrDefault(product => product.Id == id);
        }

        public void Remove(int id)
        {
            var product = _context.Products.First(p => p.Id == id);
            this._context.Products.Remove(product);
            this._context.SaveChanges();
        }

        public void Update(Product product)
        {
            this._context.Products.Update(product);
            this._context.SaveChanges();
        }
    }
}
