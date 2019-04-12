using System;

namespace Backend.Views.GeneralInformationEntities.Components
{
    public class SurgicalInterventionView
    {
        public int Id { get; set; }
        public DateTime ProcedureTime { get; set; }
        public string Diagnosis { get; set; }
        public string InterventionType { get; set; }

        public int GeneralInformationId { get; set; }
    }
}
