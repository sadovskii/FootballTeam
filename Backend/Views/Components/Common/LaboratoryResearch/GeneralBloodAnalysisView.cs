using Backend.Views.MedicalExaminationEntities.Components;

namespace Backend.Views.Common.LaboratoryResearch.Components
{
    public class GeneralBloodAnalysisView
    {
        public int Id { get; set; }
        public string Info { get; set; }

        public int MedicalExaminationId { get; set; }
    }
}
