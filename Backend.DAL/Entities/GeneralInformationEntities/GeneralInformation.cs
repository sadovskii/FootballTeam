using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Backend.DAL.Entities.GeneralInformationEntities
{
    public class GeneralInformation : BaseEntity
    {
        public GeneralInformation()
        {
            this.Fluorographies = new HashSet<Fluorography>();
            this.VaccinationStatuses = new HashSet<VaccinationStatus>();
            this.SurgicalIntervention = new HashSet<SurgicalIntervention>();
        }

        public DateTime Bithday { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }      
        public double ArterialPressure { get; set; }
        public string BloodType { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public ICollection<Fluorography> Fluorographies { get; set; }
        public ICollection<VaccinationStatus> VaccinationStatuses { get; set; }
        public ICollection<SurgicalIntervention> SurgicalIntervention { get; set; }
    }
}
