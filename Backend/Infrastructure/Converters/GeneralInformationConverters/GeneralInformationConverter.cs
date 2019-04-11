using Backend.DAL.Entities.GeneralInformationEntities;
using Backend.Views.GeneralInformationEntities.Components;
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
            if (view != null)
            {
                return new GeneralInformation
                {
                    Id = view.Id,
                    Bithday = view.Birthday,
                    Weight = view.Weight,
                    Height = view.Height,
                    ArterialPressure = view.ArterialPressure,
                    BloodType = view.BloodType,
                    PatientId = view.PatientId,
                    Fluorographies = view.Fluorographies.ViewToEntity() ?? new List<Fluorography>(),
                    VaccinationStatuses = view.VaccinationStatuses.ViewToEntity() ?? new List<VaccinationStatus>(),
                    SurgicalIntervention = view.SurgicalIntervention.ViewToEntity() ?? new List<SurgicalIntervention>()
                };
            }

            return null;

        }

        public static List<GeneralInformation> ViewToEntity(this IEnumerable<GeneralInformationView> views)
        {
            return views?.Select(t => t.ViewToEntity()).ToList();
        }

        public static GeneralInformationView EntityToView(this GeneralInformation entity)
        {
            if (entity != null)
            {
                return new GeneralInformationView
                {
                    Id = entity.Id,
                    Birthday = entity.Bithday,
                    Weight = entity.Weight,
                    Height = entity.Height,
                    ArterialPressure = entity.ArterialPressure,
                    BloodType = entity.BloodType,
                    PatientId = entity.PatientId,
                    Fluorographies = entity.Fluorographies.EntityToView() ?? new List<FluorographyView>(),
                    VaccinationStatuses = entity.VaccinationStatuses.EntityToView() ?? new List<VaccinationStatusView>(),
                    SurgicalIntervention = entity.SurgicalIntervention.EntityToView() ?? new List<SurgicalInterventionView>()
                };
            }

            return null;

        }

        public static List<GeneralInformationView> EntityToView(this IEnumerable<GeneralInformation> entities)
        {
            return entities?.Select(t => t.EntityToView()).ToList() ?? new List<GeneralInformationView>();
        }
    }
}
