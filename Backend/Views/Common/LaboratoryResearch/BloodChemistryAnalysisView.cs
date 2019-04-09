using Backend.Views.MedicalExaminationEntities;
using System.ComponentModel.DataAnnotations;

namespace Backend.Views.Common.LaboratoryResearch
{
    public class BloodChemistryAnalysisView
    {
        [Key]
        public int Id { get; set; }
        public string Info { get; set; }

        public MedicalExaminationView MedicalExamination { get; set; }
    }
}
