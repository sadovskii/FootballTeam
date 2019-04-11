using Backend.Views.Base;
using Backend.Views.Components;
using System;
using System.Collections.Generic;

namespace Backend.Views.GeneralInformationEntities.Components
{
    public class GeneralInformationView : BaseResponse
    {
        public int Id { get; set; }
        public DateTime Birthday { get; set; }
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
