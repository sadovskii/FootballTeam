using Backend.DAL.EF;
using Backend.DAL.Entities.MedicalExaminationEntities;
using Backend.DAL.Interfaces.Repositories.Other.MedicalExamination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.DAL.Repositories.Other.MedicalExamination
{
    public class DoctorsDiagnosisRepository : GenericRepository<ApplicationContext, DoctorsDiagnosis>, IDoctorsDiagnosisRepository
    {
        public DoctorsDiagnosisRepository(ApplicationContext context) : base(context) { }
    }
}
