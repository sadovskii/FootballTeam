using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Views.GeneralInformationEntities.Components
{
    public class VaccinationStatusView
    {
        [Key]
        public int Id { get; set; } 
        public DateTime ProcedureTime { get; set; }
        public string Information { get; set; }

        public int GeneralInformationId { get; set; }
        public GeneralInformationView GeneralInformation { get; set; }
    }
}
