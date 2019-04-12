using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Views.Base
{
    public class BaseResponse<T> : BaseResponse
    { 
        public T Elem { get; set; }
    }

    public class BaseResponse
    {
        public StatusInfo StatusInfo { get; set; }
    }   
}
