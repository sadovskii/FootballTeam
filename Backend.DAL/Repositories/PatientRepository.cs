using Backend.DAL.EF;
using Backend.DAL.Entities;
using Backend.DAL.Entities.GeneralInformationEntities;
using Backend.DAL.Entities.InjuriesDiseasesEntities;
using Backend.DAL.Entities.MedicalExaminationEntities;
using Backend.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Backend.DAL.Repositories
{
    public class PatientRepository : GenericRepository<ApplicationContext, Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationContext context) : base(context)
        {   
        }

        public Patient GetGeneralInformationByIdFull(int id)
        {
            return context.Patients
                .Include(t => t.GeneralInformation).ThenInclude(t => t.Fluorographies)
                .Include(t => t.GeneralInformation).ThenInclude(t => t.VaccinationStatuses)
                .Include(t => t.GeneralInformation).ThenInclude(t => t.SurgicalIntervention)
                .FirstOrDefault(t => t.Id == id);
        }

        public Patient GetMedicalExaminationByIdFull(int id)
        {
            return context.Patients
                .Include(t => t.MedicalExaminations).ThenInclude(t => t.DoctorsDiagnoses)
                .Include(t => t.MedicalExaminations).ThenInclude(t => t.BloodChemistryAnalyses)
                .Include(t => t.MedicalExaminations).ThenInclude(t => t.GeneralBloodAnalyses)
                .Include(t => t.MedicalExaminations).ThenInclude(t => t.GeneralUrineAnalyses)
                .Include(t => t.MedicalExaminations).ThenInclude(t => t.HeartUltrasounds)
                .Include(t => t.MedicalExaminations).ThenInclude(t => t.Electrocardiograms)
                .FirstOrDefault(t => t.Id == id);
        }

        public Patient GetInjuriesDiseasesByIdFull(int id)
        {
            return context.Patients
                .Include(t => t.InjuriesDiseases).ThenInclude(t => t.MRIs)
                .Include(t => t.InjuriesDiseases).ThenInclude(t => t.HeartUltrasounds)
                .Include(t => t.InjuriesDiseases).ThenInclude(t => t.DisabilityType)
                .FirstOrDefault(t => t.Id == id);
        }

        public Patient GetGeneralInformationById(int id)
        {
            return context.Patients
                .Include(t => t.GeneralInformation)
                .FirstOrDefault(t => t.Id == id);
        }

        public Patient GetMedicalExaminationById(int id)
        {
            return context.Patients
                .Include(t => t.MedicalExaminations)
                .FirstOrDefault(t => t.Id == id);
        }

        public Patient GetInjuriesDiseasesById(int id)
        {
            return context.Patients
                .Include(t => t.InjuriesDiseases)
                .FirstOrDefault(t => t.Id == id);
        }

        public void InsertWithDefaultGeneralInformation(Patient patient)
        {
            if (patient == null)
                throw new NullReferenceException();

            patient.Id = 0;
            patient.GeneralInformation = new GeneralInformation(){ BloodType = String.Empty};

            Insert(patient);
        }


        public void InsertGeneralInformation(int id, GeneralInformation generalInformation)
        {
            var entity = context.Patients.FirstOrDefault(t => t.Id == id);

            if (entity == null)
                throw new NullReferenceException();
            else
                entity.GeneralInformation = generalInformation;

            context.SaveChanges();
        }

        public void InsertMedicalExamination(int id, MedicalExamination generalInformation)
        {
            var entity = context.Patients.FirstOrDefault(t => t.Id == id);

            if (entity == null)
                throw new NullReferenceException();

            generalInformation.Id = 0;
            entity.MedicalExaminations.Add(generalInformation);

            context.SaveChanges();
        }

        public void InsertInjuriesDiseases(int id, InjuriesDiseases generalInformation)
        {
            var entity = context.Patients.FirstOrDefault(t => t.Id == id);

            if (entity == null)
                throw new NullReferenceException();

            entity.InjuriesDiseases.Add(generalInformation);

            context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var entity = context.Patients.FirstOrDefault(t => t.Id == id);

            if (entity == null)
                throw new NullReferenceException();
            else
                Delete(entity);

            context.SaveChanges();
        }
    }
}
