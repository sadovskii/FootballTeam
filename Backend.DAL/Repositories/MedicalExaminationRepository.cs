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

        public MedicalExamination GetWithBloodChemistryAnalysisById(int id)
        {
            return context.MedicalExaminations
                .Include(t => t.BloodChemistryAnalyses)
                .FirstOrDefault(t => t.Id == id);
        }

        public MedicalExamination GetWithDoctorsDiagnosisById(int id)
        {
            return context.MedicalExaminations
                .Include(t => t.DoctorsDiagnoses)
                .FirstOrDefault(t => t.Id == id);
        }

        public MedicalExamination GetWithElectrocardiogramById(int id)
        {
            return context.MedicalExaminations
                .Include(t => t.Electrocardiograms)
                .FirstOrDefault(t => t.Id == id);
        }

        public MedicalExamination GetWithGeneralBloodAnalysisById(int id)
        {
            return context.MedicalExaminations
                .Include(t => t.GeneralBloodAnalyses)
               .FirstOrDefault(t => t.Id == id);
        }

        public MedicalExamination GetWithGeneralUrineAnalysisById(int id)
        {
            return context.MedicalExaminations
                .Include(t => t.GeneralUrineAnalyses)
               .FirstOrDefault(t => t.Id == id);
        }

        public MedicalExamination GetWithHeartUltrasoundById(int id)
        {
            return context.MedicalExaminations
               .FirstOrDefault(t => t.Id == id);
        }

        public void InsertBloodChemistryAnalysis(int id, BloodChemistryAnalysis bloodChemistryAnalysis)
        {
            var entity = context.MedicalExaminations.FirstOrDefault(t => t.Id == id);

            if (entity == null)
                throw new NullReferenceException();

            bloodChemistryAnalysis.Id = 0;
            entity.BloodChemistryAnalyses.Add(bloodChemistryAnalysis);


            context.SaveChanges();
        }

        public void InsertDoctorsDiagnosis(int id, DoctorsDiagnosis doctorsDiagnosis)
        {
            var entity = context.MedicalExaminations.FirstOrDefault(t => t.Id == id);

            if (entity == null)
                throw new NullReferenceException();

            doctorsDiagnosis.Id = 0;
            entity.DoctorsDiagnoses.Add(doctorsDiagnosis);

            context.SaveChanges();
        }

        public void InsertElectrocardiogram(int id, Electrocardiogram electrocardiogram)
        {
            var entity = context.MedicalExaminations.FirstOrDefault(t => t.Id == id);

            if (entity == null)
                throw new NullReferenceException();

            electrocardiogram.Id = 0;
            entity.Electrocardiograms.Add(electrocardiogram);

            context.SaveChanges();
        }

        public void InsertGeneralBloodAnalysis(int id, GeneralBloodAnalysis generalBloodAnalysis)
        {
            var entity = context.MedicalExaminations.FirstOrDefault(t => t.Id == id);

            if (entity == null)
                throw new NullReferenceException();

            generalBloodAnalysis.Id = 0;
            entity.GeneralBloodAnalyses.Add(generalBloodAnalysis);

            context.SaveChanges();
        }

        public void InsertGeneralUrineAnalysis(int id, GeneralUrineAnalysis generalUrineAnalysis)
        {
            var entity = context.MedicalExaminations.FirstOrDefault(t => t.Id == id);

            if (entity == null)
                throw new NullReferenceException();

            generalUrineAnalysis.Id = 0;
            entity.GeneralUrineAnalyses.Add(generalUrineAnalysis);

            context.SaveChanges();
        }

        public void InsertHeartUltrasound(int id, HeartUltrasound heartUltrasound)
        {
            var entity = context.MedicalExaminations.FirstOrDefault(t => t.Id == id);

            if (entity == null)
                throw new NullReferenceException();

            heartUltrasound.Id = 0;
            entity.HeartUltrasounds.Add(heartUltrasound);

            context.SaveChanges();
        }

        public bool UpdateFull(MedicalExamination medicalExamination)
        {
            var entity = GetFullById(medicalExamination.Id);

            if(entity != null)
            {
                entity.ProcedureTime = medicalExamination.ProcedureTime;
                entity.Allowance = medicalExamination.Allowance;

                if(medicalExamination.DoctorsDiagnoses != null)
                    foreach (var a in entity.DoctorsDiagnoses)
                        foreach (var b in medicalExamination.DoctorsDiagnoses)
                            if (a.Id == b.Id)
                            {
                                a.Diagnosis = b.Diagnosis;
                                a.MedicalProfessionId = b.MedicalProfessionId;
                            }

                if (medicalExamination.BloodChemistryAnalyses != null)
                    foreach (var a in entity.BloodChemistryAnalyses)
                        foreach (var b in medicalExamination.BloodChemistryAnalyses)
                            if (a.Id == b.Id)
                                a.Info = b.Info;

                if (medicalExamination.Electrocardiograms != null)
                    foreach (var a in entity.Electrocardiograms)
                        foreach (var b in medicalExamination.Electrocardiograms)
                            if (a.Id == b.Id)
                                a.Info = b.Info;

                if (medicalExamination.GeneralBloodAnalyses != null)
                    foreach (var a in entity.GeneralBloodAnalyses)
                        foreach (var b in medicalExamination.GeneralBloodAnalyses)
                            if (a.Id == b.Id)
                                a.Info = b.Info;

                if (medicalExamination.GeneralUrineAnalyses != null)
                    foreach (var a in entity.GeneralUrineAnalyses)
                        foreach (var b in medicalExamination.GeneralUrineAnalyses)
                            if (a.Id == b.Id)
                                a.Info = b.Info;

                if (medicalExamination.HeartUltrasounds != null)
                    foreach (var a in entity.HeartUltrasounds)
                        foreach (var b in medicalExamination.HeartUltrasounds)
                            if (a.Id == b.Id)
                                a.Info = b.Info;


                Update(entity);
                context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
