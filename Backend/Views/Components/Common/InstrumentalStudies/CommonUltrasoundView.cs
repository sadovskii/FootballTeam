using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Views.Components.Common.InstrumentalStudies
{
    public class CommonUltrasoundView
    {
        public int Id { get; set; }
        public string Info { get; set; }
        public IFormFile File { get; set; }
        public int InjuriesDiseasesId { get; set; }
    }
}
