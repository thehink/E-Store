using EStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Repositories
{
    public abstract class BaseRepository
    {

        protected ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
    }
}
