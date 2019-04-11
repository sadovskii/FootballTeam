using Backend.Infrastructure.Enums;
using Backend.Views.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Views.MedicalExaminationEntities
{
    public class DoctorsDiagnosisView
    {
        public int Id { get; set; }
        public string Diagnosis { get; set; }

        public int MedicalExaminationId { get; set; }
        public MedicalExaminationView MedicalExamination { get; set; }
        public MedicalProfession MedicalProfession { get; set; }
    }
}
