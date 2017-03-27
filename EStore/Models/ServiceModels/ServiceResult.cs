using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Models.ServiceModels
{
    public class ServiceResult
    {
        public delegate void Delegate();

        public ServiceResult()
        {

        }

        public ServiceResult(Delegate func)
        {
            try {
                func();
            } catch(Exception error)
            {
                this.Status = ServiceResultStatus.Error;
                this.Message = error.Message;
            }
        }

        public ServiceResultStatus Status { get; set; }

        public string Message { get; set; }

        public bool Succeeded => this.Status == ServiceResultStatus.Success;
    }
}
