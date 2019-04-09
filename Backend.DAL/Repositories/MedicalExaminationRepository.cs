using Backend.DAL.EF;
using Backend.DAL.Entities.Common.InstrumentalStudies;
using Backend.DAL.Entities.Common.LaboratoryResearch;
using Backend.DAL.Entities.MedicalExaminationEntities;
using Backend.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.DAL.Repositories
{
    public class MedicalExaminationRepository : GenericRepository<ApplicationContext, MedicalExamination>, IMedicalExaminationRepository
    {
        public MedicalExaminationRepository(ApplicationContext context) : base(context)
        {
        }

        public MedicalExamination GetFullById(int id)
        {
            return context.MedicalExaminations
                .Include(t => t.BloodChemistryAnalyses)
                .Include(t => t.DoctorsDiagnoses)
                .Include(t => t.Electrocardiograms)
                .Include(t => t.GeneralBloodAnalyses)
                .Include(t => t.GeneralUrineAnalyses)
                .Include(t => t.HeartUltrasounds)
                .FirstOrDefault(t => t.Id == id);
        }

        public List<BloodChemistryAnalysis> GetBloodChemistryAnalysisById(int id)
        {
            return context.MedicalExaminations
                .FirstOrDefault(t => t.Id == id).BloodChemistryAnalyses
                .ToList();
        }

        public List<DoctorsDiagnosis> GetDoctorsDiagnosisById(int id)
        {
            return context.MedicalExaminations
                .FirstOrDefault(t => t.Id == id).DoctorsDiagnoses
                .ToList();
        }

        public List<Electrocardiogram> GetElectrocardiogramById(int id)
        {
            return context.MedicalExaminations
                .FirstOrDefault(t => t.Id == id).Electrocardiograms
                .ToList();
        }

        public List<GeneralBloodAnalysis> GetGeneralBloodAnalysisById(int id)
        {
            return context.MedicalExaminations
               .FirstOrDefault(t => t.Id == id).GeneralBloodAnalyses
               .ToList();
        }

        public List<GeneralUrineAnalysis> GetGeneralUrineAnalysisById(int id)
        {
            return context.MedicalExaminations
               .FirstOrDefault(t => t.Id == id).GeneralUrineAnalyses
               .ToList();
        }

        public List<HeartUltrasound> GetHeartUltrasoundById(int id)
        {
            return context.MedicalExaminations
               .FirstOrDefault(t => t.Id == id).HeartUltrasounds
               .ToList();
        }

        public void InsertBloodChemistryAnalysis(int id, BloodChemistryAnalysis bloodChemistryAnalysis)
        {
            var entity = context.MedicalExaminations.FirstOrDefault(t => t.Id == id);

            if (entity == null)
                throw new NullReferenceException();
            else
                entity.BloodChemistryAnalyses.Add(bloodChemistryAnalysis);

            context.SaveChanges();
        }

        public void InsertDoctorsDiagnosis(int id, DoctorsDiagnosis doctorsDiagnosis)
        {
            var entity = context.MedicalExaminations.FirstOrDefault(t => t.Id == id);

            if (entity == null)
                throw new NullReferenceException();
            else
                entity.DoctorsDiagnoses.Add(doctorsDiagnosis);

            context.SaveChanges();
        }

        public void InsertElectrocardiogram(int id, Electrocardiogram electrocardiogram)
        {
            var entity = context.MedicalExaminations.FirstOrDefault(t => t.Id == id);

            if (entity == null)
                throw new NullReferenceException();
            else
                entity.Electrocardiograms.Add(electrocardiogram);

            context.SaveChanges();
        }

        public void InsertGeneralBloodAnalysis(int id, GeneralBloodAnalysis generalBloodAnalysis)
        {
            var entity = context.MedicalExaminations.FirstOrDefault(t => t.Id == id);

            if (entity == null)
                throw new NullReferenceException();
            else
                entity.GeneralBloodAnalyses.Add(generalBloodAnalysis);

            context.SaveChanges();
        }

        public void InsertGeneralUrineAnalysis(int id, GeneralUrineAnalysis generalUrineAnalysis)
        {
            var entity = context.MedicalExaminations.FirstOrDefault(t => t.Id == id);

            if (entity == null)
                throw new NullReferenceException();
            else
                entity.GeneralUrineAnalyses.Add(generalUrineAnalysis);

            context.SaveChanges();
        }

        public void InsertHeartUltrasound(int id, HeartUltrasound heartUltrasound)
        {
            var entity = context.MedicalExaminations.FirstOrDefault(t => t.Id == id);

            if (entity == null)
                throw new NullReferenceException();
            else
                entity.HeartUltrasounds.Add(heartUltrasound);

            context.SaveChanges();
        }
    }
}
