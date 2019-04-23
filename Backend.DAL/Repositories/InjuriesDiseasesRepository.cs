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
                .Include(t => t.CommonUltrasounds)
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

        public void InsertCommonUltrasound(int id, CommonUltrasound commonUltrasound)
        {
            var entity = context.InjuriesDiseases.FirstOrDefault(t => t.Id == id);

            if (entity == null)
                throw new NullReferenceException();

            commonUltrasound.Id = 0;
            entity.CommonUltrasounds.Add(commonUltrasound);

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
                {
                    foreach (var a in entity.MRIs)
                        foreach (var b in injuriesDiseases.MRIs)
                            if (a.Id == b.Id && b.Info != null)
                                a.Info = b.Info;

                    foreach (var a in injuriesDiseases.MRIs)
                        if (a.Id == 0)
                            entity.MRIs.Add(a);
                 
                }

                if (injuriesDiseases.CommonUltrasounds != null)
                {
                    foreach (var a in entity.CommonUltrasounds)
                        foreach (var b in injuriesDiseases.CommonUltrasounds)
                            if (a.Id == b.Id && b.Info != null)
                                a.Info = b.Info;

                    foreach (var a in injuriesDiseases.CommonUltrasounds)
                        if (a.Id == 0)
                            entity.CommonUltrasounds.Add(a);
                }
                    

                if (injuriesDiseases.Radiographies != null)
                {
                    foreach (var a in entity.Radiographies)
                        foreach (var b in injuriesDiseases.Radiographies)
                            if (a.Id == b.Id && b.Info != null)
                                a.Info = b.Info;

                    foreach (var a in injuriesDiseases.Radiographies)
                        if (a.Id == 0)
                            entity.Radiographies.Add(a);
                }
                    

                Update(entity);
                return true;
            }

            return false;
        }
    }
}
