using Backend.DAL.Entities.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.DAL.Entities.MedicalExaminationEntities
{
    public class DoctorsDiagnosis : BaseEntity
    {
        public string Diagnosis { get; set; }

        public int MedicalExaminationId { get; set; }
        public int MedicalProfessionId { get; set; }
        public MedicalProfession MedicalProfession { get; set; }
    }
}
