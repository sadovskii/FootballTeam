using Backend.DAL.Entities.InjuriesDiseasesEntities;
using Backend.DAL.Entities.MedicalExaminationEntities;
using System.ComponentModel.DataAnnotations;

namespace Backend.DAL.Entities.Common.InstrumentalStudies
{
    public class HeartUltrasound : BaseEntity
    {
        public string Info { get; set; }

        public int? MedicalExaminationId { get; set; }
        public MedicalExamination MedicalExamination { get; set; }

        public int? InjuriesDiseasesId { get; set; }
        public InjuriesDiseases InjuriesDiseases { get; set; }


    }
}
