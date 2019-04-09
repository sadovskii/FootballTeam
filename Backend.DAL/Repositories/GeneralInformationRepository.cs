using Backend.DAL.EF;
using Backend.DAL.Entities.GeneralInformationEntities;
using Backend.DAL.Entities.InjuriesDiseasesEntities;
using Backend.DAL.Entities.MedicalExaminationEntities;
using Backend.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.DAL.Repositories
{
    public class GeneralInformationRepository : GenericRepository<ApplicationContext, GeneralInformation>, IGeneralInformationRepository
    {
        public GeneralInformationRepository(ApplicationContext context) : base(context) { }

        public GeneralInformation GetFullById(int id)
        {
            return context.GeneralInformation
                .Include(t => t.Fluorographies)
                .Include(t => t.SurgicalIntervention)
                .Include(t => t.VaccinationStatuses)
                .FirstOrDefault(t => t.Id == id);
        }

        public GeneralInformation GetFluorographyById(int id)
        {
            return context.GeneralInformation
                .FirstOrDefault(t => t.Id == id);
        }

        public GeneralInformation GetSurgicalInterventionById(int id)
        {
            return context.GeneralInformation
                .FirstOrDefault(t => t.Id == id);
        }

        public GeneralInformation GetVaccinationStatusById(int id)
        {
            return context.GeneralInformation
                .FirstOrDefault(t => t.Id == id);
        }

        public void InserSurgicalIntervention(int id, SurgicalIntervention surgicalIntervention)
        {
            var entity = context.GeneralInformation.FirstOrDefault(t => t.Id == id);

            if (entity == null)
                throw new NullReferenceException();
            else
                entity.SurgicalIntervention.Add(surgicalIntervention);

            context.SaveChanges();
        }

        public void InsertFluorography(int id, Fluorography fluorography)
        {
            var entity = context.GeneralInformation.FirstOrDefault(t => t.Id == id);

            if (entity == null)
                throw new NullReferenceException();
            else
                entity.Fluorographies.Add(fluorography);

            context.SaveChanges();
        }

        public void InsertVaccinationStatus(int id, VaccinationStatus vaccinationStatus)
        {
            var entity = context.GeneralInformation.FirstOrDefault(t => t.Id == id);

            if (entity == null)
                throw new NullReferenceException();
            else
                entity.VaccinationStatuses.Add(vaccinationStatus);

            context.SaveChanges();
        }
    }
}
