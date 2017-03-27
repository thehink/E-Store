using EStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Repositories
{
    public interface IProductRepository : IRepository<Product, int>
    {
        IEnumerable<Product> Filter(string query, int categoryId);
    }
}
