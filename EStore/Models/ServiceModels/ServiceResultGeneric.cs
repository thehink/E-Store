using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Models.ServiceModels
{
    public class ServiceResult<T> : ServiceResult
    {
        public string ResponseType { get; set; } = typeof(T).Name;
        public T Data { get; set; }
    }
}
