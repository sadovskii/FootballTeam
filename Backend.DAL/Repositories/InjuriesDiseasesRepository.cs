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
                 .FirstOrDefault(t => t.Id == id);
        }

        public InjuriesDiseases GetMRIById(int id)
        {
            return context.InjuriesDiseases
                .FirstOrDefault(t => t.Id == id);
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

        public override void Delete(int id)
        {
            var entity = context.InjuriesDiseases.FirstOrDefault(t => t.Id == id);

            if (entity == null)
                throw new NullReferenceException();
            else
                Delete(entity);

            context.SaveChanges();
        }

    }
}
