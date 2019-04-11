using Backend.Views.Base;
using Backend.Views.MedicalExaminationEntities.Components;

namespace Backend.Views.Common.LaboratoryResearch.Components
{
    public class GeneralUrineAnalysisView : BaseResponse
    {
        public int Id { get; set; }
        public string Info { get; set; }

        public int MedicalExaminationId { get; set; }
        public MedicalExaminationView MedicalExamination { get; set; }
    }
}
