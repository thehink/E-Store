using EStore.Models;
using EStore.Models.ServiceModels;
using EStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public ServiceResultCollection<Category> GetAll()
        {
            return new ServiceResultCollection<Category>(() => {
                return this._categoryRepository.GetAll().ToList();
            });
        }

        public ServiceResult Create(Category category)
        {
            return new ServiceResult(() => {
                this._categoryRepository.Add(category);
            });
        }

        public ServiceResult<Category> Find(int id)
        {
            return new ServiceResult<Category>(() => {
                return this._categoryRepository.Find(id);
            });
        }

        public ServiceResult Remove(int id)
        {
            return new ServiceResult(() => {
                this._categoryRepository.Remove(id);
            });
        }

        public ServiceResult Update(Category category)
        {
            return new ServiceResult(() => {
                this._categoryRepository.Update(category);
            });
        }
    }
}
