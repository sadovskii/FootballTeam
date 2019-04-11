using Backend.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Helpers
{
    public class SettingHelper
    {
        public static StatusInfo SetBaseResponse(int status, string errorMessage = "")
        {
            return new StatusInfo() { Status = status, ErrorMessage = errorMessage };
        }

        
    }
}
