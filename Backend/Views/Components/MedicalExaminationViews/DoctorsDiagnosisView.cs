using Backend.Infrastructure.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Backend.Views.MedicalExaminationEntities.Components
{
    public class DoctorsDiagnosisView
    {
        public int Id { get; set; }
        public string Diagnosis { get; set; }

        public int MedicalExaminationId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public MedicalProfession MedicalProfession { get; set; }
    }
}
