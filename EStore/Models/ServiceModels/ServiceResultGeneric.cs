using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Models.ServiceModels
{
    public class ServiceResult<T> : ServiceResult
    {

        public new delegate T Delegate();

        public ServiceResult(Delegate func)
        {
            try
            {
                this.Data = func();
                if(this.Data == null)
                {
                    this.Status = ServiceResultStatus.Error;
                    this.Message = "No data";
                } 
            }
            catch (Exception error)
            {
                this.Status = ServiceResultStatus.Error;
                this.Message = error.Message;
            }
        }

        public string ResponseType { get; set; } = typeof(T).Name;
        public virtual T Data { get; set; }
    }
}
