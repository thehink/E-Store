using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Models
{
    public enum OrderStatus
    {
        Idle,
        Processing,
        Shipped,
        Complete
    }
}
