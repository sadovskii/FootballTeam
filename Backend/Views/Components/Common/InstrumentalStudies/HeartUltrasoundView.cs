using Backend.Views.MedicalExaminationEntities.Components;
using Microsoft.AspNetCore.Http;

namespace Backend.Views.Common.InstrumentalStudies.Components
{
    public class HeartUltrasoundView
    {
        public int Id { get; set; }
        public string Info { get; set; }
        public IFormFile File { get; set; }
        public int? MedicalExaminationId { get; set; }
        public int? InjuriesDiseasesId { get; set; }
    }
}
