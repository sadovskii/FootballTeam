using Backend.Views.MedicalExaminationEntities.Components;

namespace Backend.Views.Common.InstrumentalStudies.Components
{
    public class HeartUltrasoundView
    {
        public int Id { get; set; }
        public string Info { get; set; }

        public int MedicalExaminationId { get; set; }
    }
}
