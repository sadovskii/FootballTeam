using Backend.Views.MedicalExaminationEntities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Views.Common
{
    public class MedicalProfessionView
    {
        [Key]
        public int Id { get; set; }
        public string ProfessionName { get; set; }
        public ICollection<DoctorsDiagnosisView>  DoctorsDiagnosis { get; set; }
    }
}
