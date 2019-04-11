using Backend.Infrastructure.Enums;
using Backend.Views.Base;

namespace Backend.Views.MedicalExaminationEntities.Components
{
    public class DoctorsDiagnosisView : BaseResponse
    {
        public int Id { get; set; }
        public string Diagnosis { get; set; }

        public int MedicalExaminationId { get; set; }
        public MedicalExaminationView MedicalExamination { get; set; }
        public MedicalProfession MedicalProfession { get; set; }
    }
}
