using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Backend.Views.GeneralInformationEntities
{
    public class FluorographyView
    {
        public int Id { get; set; }
        public DateTime ProcedureTime { get; set; }
        public string Information { get; set; }

        public int GeneralInformationId { get; set; }
        public GeneralInformationView GeneralInformation { get; set; }
    }
}
