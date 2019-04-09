using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Backend.DAL.Entities.GeneralInformationEntities
{
    public class SurgicalIntervention : BaseEntity
    {
        public DateTime ProcedureTime { get; set; }
        public string Diagnosis { get; set; }
        public string InterventionType { get; set; }

        public int GeneralInformationId { get; set; }
        public GeneralInformation GeneralInformation { get; set; }
    }
}
