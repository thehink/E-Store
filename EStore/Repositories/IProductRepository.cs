using EStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Repositories
{
    public interface IProductRepository
    {
        void Add(Product item);
        IEnumerable<Product> Filter(string query, int categoryId);
        IEnumerable<Product> GetAll();
        Product Find(int id);
        void Remove(int id);
        void Update(Product item);
    }
}
