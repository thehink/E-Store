using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Models.ServiceModels
{
    public class ServiceResultCollection<T> : ServiceResult
    {
        public int Results { get; set; }
        public int TotalResults { get; set; }
        public int Index { get; set; }
        public int Limit { get; set; }
        public List<T> Data { get; set; }
    }
}
