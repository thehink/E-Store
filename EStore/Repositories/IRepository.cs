using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Repositories
{
    public interface IRepository<TEntity, TPrimaryKey>
    {
        void Add(TEntity obj);

        TEntity Find(TPrimaryKey id);

        IEnumerable<TEntity> GetAll();

        void Update(TEntity obj);

        void Remove(TPrimaryKey id);
    }
}
