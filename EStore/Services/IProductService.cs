using EStore.Models;
using EStore.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Services
{
    public interface IProductService
    {
        ServiceResultCollection<Product> FilterProducts(string query = "", int category = 0);
        ServiceResultCollection<Category> GetCategories();
        ServiceResult<Product> Find(int id);
    }
}
