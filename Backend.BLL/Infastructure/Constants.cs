using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Backend.BLL.Infastructure
{
    public static class Constants
    {
        public static string PathFileFolder { get; set; }

        static Constants()
        {
            //#if DEBUG
            //          PathFileFolder = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\\images\");
            //#else
            //			PathFileFolder = @"h:\root\home\nasta1234-001\www\source\";
            //#endif
            PathFileFolder = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\\images\");
        }
    }
}
