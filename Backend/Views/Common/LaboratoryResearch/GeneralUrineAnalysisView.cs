using Backend.Views.MedicalExaminationEntities;
using System.ComponentModel.DataAnnotations;

namespace Backend.Views.Common.LaboratoryResearch
{
    public class GeneralUrineAnalysisView
    {
        [Key]
        public int Id { get; set; }
        public string Info { get; set; }

        public int MedicalExaminationId { get; set; }
        public MedicalExaminationView MedicalExamination { get; set; }
    }
}
