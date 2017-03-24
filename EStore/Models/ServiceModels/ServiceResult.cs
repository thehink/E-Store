using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Models.ServiceModels
{
    public class ServiceResult
    {
        public ServiceResultStatus Status { get; set; }

        public string Message { get; set; }
    }
}
