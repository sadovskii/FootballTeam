using Backend.DAL.Entities;
using Backend.DAL.Entities.GeneralInformationEntities;
using Backend.DAL.Entities.InjuriesDiseasesEntities;
using Backend.DAL.Entities.MedicalExaminationEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.DAL.Interfaces.Repositories
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        Patient GetMedicalExaminationById(int id);
        Patient GetGeneralInformationById(int id);
        Patient GetInjuriesDiseasesById(int id);

        Patient GetGeneralInformationByIdFull(int id);
        Patient GetMedicalExaminationByIdFull(int id);
        Patient GetInjuriesDiseasesByIdFull(int id);


        void InsertWithDefaultGeneralInformation(Patient patient);
        void InsertGeneralInformation(int id, GeneralInformation generalInformation);
        void InsertMedicalExamination(int id, MedicalExamination medicalExamination);
        void InsertInjuriesDiseases(int id, InjuriesDiseases injuriesDiseases);
    }
}
