using Backend.DAL.EF;
using Backend.DAL.Entities.Common.InstrumentalStudies;
using Backend.DAL.Entities.InjuriesDiseasesEntities;
using Backend.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.DAL.Repositories
{
    public class InjuriesDiseasesRepository : GenericRepository<ApplicationContext, InjuriesDiseases>, IInjuriesDiseasesRepository
    {
        public InjuriesDiseasesRepository(ApplicationContext context) : base(context)
        {
           
        }

        public InjuriesDiseases GetFullById(int id)
        {
            return context.InjuriesDiseases
                .FirstOrDefault(t => t.Id == id);
        }

        public InjuriesDiseases GetHeartUltrasoundById(int id)
        {
            return context.InjuriesDiseases
                .Include(t => t.HeartUltrasounds)
                 .FirstOrDefault(t => t.Id == id);
        }

        public InjuriesDiseases GetMRIById(int id)
        {
            return context.InjuriesDiseases
                .Include(t => t.MRIs)
                .FirstOrDefault(t => t.Id == id);
        }

        public InjuriesDiseases GetRadiographyById(int id)
        {
            var a = context.InjuriesDiseases
                .Include(t => t.Radiographies)
                .FirstOrDefault(t => t.Id == id);
            return a;
        }

        public void InsertHeartUltrasound(int id, HeartUltrasound heartUltrasound)
        {
            var entity = context.InjuriesDiseases.FirstOrDefault(t => t.Id == id);

            if (entity == null)
                throw new NullReferenceException();

            heartUltrasound.Id = 0;
            entity.HeartUltrasounds.Add(heartUltrasound);


            context.SaveChanges();
        }

        public void InsertMRI(int id, MRI mri)
        {
            var entity = context.InjuriesDiseases.FirstOrDefault(t => t.Id == id);

            if (entity == null)
                throw new NullReferenceException();

            mri.Id = 0;
            entity.MRIs.Add(mri);


            context.SaveChanges();
        }

        public void InsertRadiography(int id, Radiography radiography)
        {
            var entity = context.InjuriesDiseases.FirstOrDefault(t => t.Id == id);

            if (entity == null)
                throw new NullReferenceException();

            radiography.Id = 0;
            entity.Radiographies.Add(radiography);

            context.SaveChanges();
        }

        public bool UpdateFull(InjuriesDiseases injuriesDiseases)
        {
            var entity = GetFullById(injuriesDiseases.Id);

            if (entity != null)
            {
                entity.DateInjuriesOrDiseases = injuriesDiseases.DateInjuriesOrDiseases;
                entity.ReleasedInMainGroup = injuriesDiseases.ReleasedInMainGroup;
                entity.Diagnosis = injuriesDiseases.Diagnosis;
                entity.DisabilityCountDay = injuriesDiseases.DisabilityCountDay;
                entity.DisabilityTypeId = injuriesDiseases.DisabilityTypeId;
                entity.DrugTherapy = injuriesDiseases.DrugTherapy;
                entity.PhysiotherapyTreatment = injuriesDiseases.PhysiotherapyTreatment;
                entity.Other = injuriesDiseases.Other;

                if (injuriesDiseases.MRIs != null)
                    foreach (var a in entity.MRIs)
                        foreach (var b in injuriesDiseases.MRIs)
                            if (a.Id == b.Id)
                                a.Info = b.Info;

                if (injuriesDiseases.HeartUltrasounds != null)
                    foreach (var a in entity.HeartUltrasounds)
                        foreach (var b in injuriesDiseases.HeartUltrasounds)
                            if (a.Id == b.Id)
                                a.Info = b.Info;

                if (injuriesDiseases.Radiographies != null)
                    foreach (var a in entity.Radiographies)
                        foreach (var b in injuriesDiseases.Radiographies)
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
