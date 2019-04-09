using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Backend.DAL.Entities.GeneralInformationEntities
{
    public class VaccinationStatus : BaseEntity
    {
        public DateTime ProcedureTime { get; set; }
        public string Information { get; set; }

        public int GeneralInformationId { get; set; }
        public GeneralInformation GeneralInformation { get; set; }
    }
}
