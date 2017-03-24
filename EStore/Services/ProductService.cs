using EStore.Models;
using EStore.Models.ServiceModels;
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

        public ServiceResult<Product> Find(int id)
        {
            var product = this._productRepository.Find(id);
            return new ServiceResult<Product>()
            {
                Status = ServiceResultStatus.Success,
                Data = product
            };
        }

        public ServiceResultCollection<Product> FilterProducts(string query = "", int category = 0)
        {
            var products = this._productRepository.Filter(query, category).ToList();

            return new ServiceResultCollection<Product>()
            {
                Status = ServiceResultStatus.Success,
                Data = products
            };
        }

        public ServiceResultCollection<Category> GetCategories()
        {
            var categories = this._categoryRepository.GetAll().ToList();
            return new ServiceResultCollection<Category>()
            {
                Status = ServiceResultStatus.Success,
                Data = categories
            };
        }
    }
}
