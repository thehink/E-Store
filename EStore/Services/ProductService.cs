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

        public ServiceResult Create(Product product)
        {
            return new ServiceResult(() =>
            {
                this._productRepository.Add(product);
            });
        }

        public ServiceResult Update(Product product)
        {
            return new ServiceResult(() =>
            {
                this._productRepository.Update(product);
            });
        }

        public ServiceResult Remove(int id)
        {
            return new ServiceResult(() => {
                this._productRepository.Remove(id);
            });
        }

        public ServiceResult<Product> Find(int id)
        {
            return new ServiceResult<Product>(() => {
                return this._productRepository.Find(id);
            });
        }

        public ServiceResultCollection<Product> FilterProducts(string query = "", int category = 0)
        {
            return new ServiceResultCollection<Product>(() =>
            {
                return this._productRepository.Filter(query, category).ToList();
            });
        }

        public ServiceResultCollection<Product> GetAll()
        {
            return new ServiceResultCollection<Product>(() =>
            {
                return this._productRepository.GetAll().ToList();
            });
        }

        public ServiceResultCollection<Category> GetCategories()
        {
            return new ServiceResultCollection<Category>(() => {
                return this._categoryRepository.GetAll().ToList();
            });
        }
    }
}
