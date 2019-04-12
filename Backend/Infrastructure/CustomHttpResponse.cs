using Backend.Infrastructure.Helpers;
using Backend.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infrastructure
{
    public class CustomHttpResponse
    {
        public static BaseResponse<T> Ok<T>(T elem) where T : class
        {
            var baseResponse = new BaseResponse<T>
            {
                Elem = elem,
                StatusInfo = SettingHelper.SetBaseResponse(200)
            };

            return baseResponse;
        }

        public static BaseResponse NotFound()
        {
            return new BaseResponse { StatusInfo = SettingHelper.SetBaseResponse(404, "item's not found") };
        }

        public static BaseResponse BadResponse(string message)
        {
            return new BaseResponse { StatusInfo = SettingHelper.SetBaseResponse(500, message) };
        }
    }
}
