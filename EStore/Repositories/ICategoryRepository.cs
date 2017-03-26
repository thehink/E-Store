using EStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Repositories
{
    public interface ICategoryRepository
    {
        void Add(Category category);

        IEnumerable<Category> GetAll();

        Category Find(int id);

        void Update(Category category);

        void Remove(int id);
    }
}
