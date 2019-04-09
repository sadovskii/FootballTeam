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

        List<DoctorsDiagnosis> GetDoctorsDiagnosisById(int id);
        List<BloodChemistryAnalysis> GetBloodChemistryAnalysisById(int id);
        List<GeneralBloodAnalysis> GetGeneralBloodAnalysisById(int id);
        List<GeneralUrineAnalysis> GetGeneralUrineAnalysisById(int id);
        List<HeartUltrasound> GetHeartUltrasoundById(int id);
        List<Electrocardiogram> GetElectrocardiogramById(int id);

        void InsertDoctorsDiagnosis(int id, DoctorsDiagnosis doctorsDiagnosis);
        void InsertBloodChemistryAnalysis(int id, BloodChemistryAnalysis bloodChemistryAnalysis);
        void InsertGeneralBloodAnalysis(int id, GeneralBloodAnalysis generalBloodAnalysis);
        void InsertGeneralUrineAnalysis(int id, GeneralUrineAnalysis generalUrineAnalysis);
        void InsertHeartUltrasound(int id, HeartUltrasound heartUltrasound);
        void InsertElectrocardiogram(int id, Electrocardiogram electrocardiogram);


    }
}
