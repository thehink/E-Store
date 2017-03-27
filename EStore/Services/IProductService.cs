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
        ServiceResultCollection<Product> GetAll();

        ServiceResultCollection<Product> Search(string query = "", int category = 0, int page = 0, int limit = 10);

        ServiceResultCollection<Product> FilterProducts(string query = "", int category = 0);

        ServiceResultCollection<Category> GetCategories();

        ServiceResult Create(Product product);

        ServiceResult<Product> Find(int id);

        ServiceResult Remove(int id);

        ServiceResult Update(Product product);
    }
}
