using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Models
{
    public class CollectionResult<T>
    {
        public int Results { get; set; }
        public int Limit { get; set; }
        public int Page { get; set; }
        public int TotalResults { get; set; }
        public List<T> Items { get; set; }
    }
}
