using EStore.Models;
using EStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Services
{
    public class ProductService : IProductService
    {

        IProductRepository _productRepository;
        ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            this._productRepository = productRepository;
            this._categoryRepository = categoryRepository;
        }

        public Product Find(int id)
        {
            return this._productRepository.Find(id);
        }

        public CollectionResult<Product> FilterProducts(string query = "", int category = 0)
        {
            var products = this._productRepository.Filter(query, category);

            return new CollectionResult<Product>()
            {
                Items = products.ToList()
            };
        }

        public List<Category> GetCategories()
        {
            var categories = this._categoryRepository.GetAll();
            return categories.ToList();
        }
    }
}
