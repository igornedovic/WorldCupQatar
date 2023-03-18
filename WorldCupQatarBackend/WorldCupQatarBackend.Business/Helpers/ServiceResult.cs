using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldCupQatarBackend.Business.Helpers
{
    public class ServiceResult<T>
    {
        public bool IsBadRequest { get; set; }
        public string Message { get; set; }
        public T Payload { get; set; }

        public ServiceResult<T> BadRequestMessage(string message)
        {
            IsBadRequest = true;
            Message = message;
            return this;
        }
    }
}