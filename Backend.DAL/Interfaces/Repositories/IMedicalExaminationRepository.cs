using Backend.DAL.Entities.Common.InstrumentalStudies;
using Backend.DAL.Entities.Common.LaboratoryResearch;
using Backend.DAL.Entities.MedicalExaminationEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.DAL.Interfaces.Repositories
{
    public interface IMedicalExaminationRepository : IGenericRepository<MedicalExamination>
    {
        MedicalExamination GetFullById(int id);

        MedicalExamination GetWithDoctorsDiagnosisById(int id);
        MedicalExamination GetWithBloodChemistryAnalysisById(int id);
        MedicalExamination GetWithGeneralBloodAnalysisById(int id);
        MedicalExamination GetWithGeneralUrineAnalysisById(int id);
        MedicalExamination GetWithHeartUltrasoundById(int id);
        MedicalExamination GetWithElectrocardiogramById(int id);

        void InsertDoctorsDiagnosis(int id, DoctorsDiagnosis doctorsDiagnosis);
        void InsertBloodChemistryAnalysis(int id, BloodChemistryAnalysis bloodChemistryAnalysis);
        void InsertGeneralBloodAnalysis(int id, GeneralBloodAnalysis generalBloodAnalysis);
        void InsertGeneralUrineAnalysis(int id, GeneralUrineAnalysis generalUrineAnalysis);
        void InsertHeartUltrasound(int id, HeartUltrasound heartUltrasound);
        void InsertElectrocardiogram(int id, Electrocardiogram electrocardiogram);


    }
}
