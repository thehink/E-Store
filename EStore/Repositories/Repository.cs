using EStore.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Repositories
{
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class
    {

        protected DbSet<TEntity> _context;
        protected ApplicationDbContext _DbContext;

        public Repository(ApplicationDbContext context)
        {
            this._DbContext = context;
            this._context = context.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            this._context.Add(obj);
            this._DbContext.SaveChanges();
        }

        public virtual TEntity Find(TPrimaryKey id)
        {
            return this._context.Find(id);
        }

        public virtual void Update(TEntity obj)
        {
            this._context.Update(obj);
            this._DbContext.SaveChanges();
        }

        public virtual void Remove(TPrimaryKey id)
        {
            var obj = this._context.Find(id);
            this._context.Remove(obj);
            this._DbContext.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return this._context.ToList();
        }
    }
}
