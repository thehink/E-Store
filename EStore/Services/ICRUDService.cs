using EStore.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Services
{
    public interface ICRUDService<T>
    {
        ServiceResultCollection<T> GetAll();

        ServiceResult Create(T obj);

        ServiceResult<T> Find(int id);

        ServiceResult Remove(int id);

        ServiceResult Update(T obj);
    }
}
