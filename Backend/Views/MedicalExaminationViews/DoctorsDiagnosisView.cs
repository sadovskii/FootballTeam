using Backend.Views.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Views.MedicalExaminationEntities
{
    public class DoctorsDiagnosisView
    {
        [Key]
        public int Id { get; set; }
        public string Diagnosis { get; set; }

        public int MedicalExaminationId { get; set; }
        public int MedicalProfessionId { get; set; }
        public MedicalExaminationView MedicalExamination { get; set; }
        public MedicalProfessionView MedicalProfession { get; set; }
    }
}
