using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Models.ServiceModels
{
    public class ServiceResultCollection<T> : ServiceResult<List<T>>
    {
        public ServiceResultCollection(Delegate func) : base(func)
        {
        }

        public int Results { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
        public override List<T> Data { get; set; }
    }
}
