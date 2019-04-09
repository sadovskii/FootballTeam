using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Backend.Views.GeneralInformationEntities
{
    public class GeneralInformationView
    {
        [Key]
        public int Id { get; set; }
        public DateTime Bithday { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }      
        public double ArterialPressure { get; set; }
        public string BloodType { get; set; }

        public int PatientId { get; set; }
        public PatientView Patient { get; set; }

        public ICollection<FluorographyView> Fluorographies { get; set; }
        public ICollection<VaccinationStatusView> VaccinationStatuses { get; set; }
        public ICollection<SurgicalInterventionView> SurgicalIntervention { get; set; }
    }
}
