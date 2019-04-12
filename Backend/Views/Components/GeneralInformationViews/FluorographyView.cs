using System;

namespace Backend.Views.GeneralInformationEntities.Components
{
    public class FluorographyView
    {
        public int Id { get; set; }
        public DateTime ProcedureTime { get; set; }
        public string Information { get; set; }
    }
}
