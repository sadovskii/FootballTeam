using Backend.DAL.Entities.GeneralInformationEntities;
using Backend.Views.GeneralInformationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Converters.GeneralInformationConverters
{
    internal static class GeneralInformationConverter
    {
        public static GeneralInformation ViewToEntity(this GeneralInformationView view)
        {
            return new GeneralInformation
            {
                Id = view.Id,
                Bithday = view.Bithday,
                Weight = view.Weight,
                Height = view.Height,
                ArterialPressure = view.ArterialPressure,
                BloodType = view.BloodType,
                PatientId = view.PatientId,
                //Fluorographies = view.Fluorographies,
                //VaccinationStatuses = view.VaccinationStatuses,
                //SurgicalIntervention = view.SurgicalIntervention
            };
        }

        public static List<GeneralInformation> ViewToEntity(this IEnumerable<GeneralInformationView> views)
        {
            return views.Select(t => t.ViewToEntity()).ToList();
        }

        public static GeneralInformationView EntityToView(this GeneralInformation entity)
        {
            return new GeneralInformationView
            {
                Id = entity.Id,
                Bithday = entity.Bithday,
                Weight = entity.Weight,
                Height = entity.Height,
                ArterialPressure = entity.ArterialPressure,
                BloodType = entity.BloodType,
                PatientId = entity.PatientId,
                //Fluorographies = entity.Fluorographies,
                //VaccinationStatuses = entity.VaccinationStatuses,
                //SurgicalIntervention = entity.SurgicalIntervention
            };
        }

        public static List<GeneralInformationView> EntityToView(this IEnumerable<GeneralInformation> entities)
        {
            var a = entities.Select(t => t.EntityToView());
            return a.ToList();
        }
    }
}
