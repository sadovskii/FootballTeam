using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Views.Base
{
    public class BaseResponse<T>
    {
        public T elem { get; set; }
        public StatusInfo StatusInfo { get; set; }
    }
}
