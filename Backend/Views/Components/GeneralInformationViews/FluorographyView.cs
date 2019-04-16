using System;
using Microsoft.AspNetCore.Http;

namespace Backend.Views.GeneralInformationEntities.Components
{
    public class FluorographyView
    {
        public int Id { get; set; }
        public DateTime ProcedureTime { get; set; }
        public string Information { get; set; }
        public IFormFile File { get; set; }
    }
}
