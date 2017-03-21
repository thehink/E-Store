using EStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Repositories
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        void AddSubCategory(SubCategory category);
        IEnumerable<Category> GetAll();
    }
}
