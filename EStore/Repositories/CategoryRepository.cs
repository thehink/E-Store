using EStore.Data;
using EStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void AddCategory(Category category)
        {

        }

        public void AddSubCategory(SubCategory subCategory)
        {

        }

        public IEnumerable<Category> GetAll(){
            return this._context.Categories.ToList();
        }

    }
}
