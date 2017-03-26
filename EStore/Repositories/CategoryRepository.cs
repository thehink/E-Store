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

        public void Add(Category category)
        {
            this._context.Categories.Add(category);
            this._context.SaveChanges();
        }

        public void Update(Category category)
        {
            this._context.Categories.Update(category);
            this._context.SaveChanges();
        }

        public void Remove(int id)
        {
            var category = _context.Categories.First(p => p.Id == id);
            this._context.Categories.Remove(category);
            this._context.SaveChanges();
        }

        public IEnumerable<Category> GetAll(){
            return this._context.Categories.ToList();
        }

        public Category Find(int id)
        {
            return this._context.Categories.FirstOrDefault(c => c.Id == id);
        }


    }
}
