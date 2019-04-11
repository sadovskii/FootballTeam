using Backend.Infrastructure.Helpers;
using Backend.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infrastructure
{
    public class HttpResponse
    {
        public static BaseResponse<T> Ok<T>(T elem) where T : class
        {
            var baseResponse = new BaseResponse<T>
            {
                elem = elem,
                StatusInfo = SettingHelper.SetBaseResponse(200)
            };

            return baseResponse;
        }
    }
}
