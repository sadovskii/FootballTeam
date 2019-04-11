using Backend.DAL.Entities.InjuriesDiseasesEntities;
using Backend.Views.InjuriesDiseasesEntities.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DAL.Entities.Common.InstrumentalStudies;
using Backend.Infrastructure.Converters.Common.InstrumentalStudies;
using Backend.Views.Common.InstrumentalStudies.Components;
using Enums = Backend.Infrastructure.Enums;

namespace Backend.Infrastructure.Converters.InjuriesDiseasesConverters
{
    internal static class InjuriesDiseasesConverter
    {
        public static InjuriesDiseases ViewToEntity(this InjuriesDiseasesView view)
        {
            if (view != null)
            {
                return new InjuriesDiseases
                {
                    Id = view.Id,
                    DateInjuriesOrDiseases = view.DateInjuriesOrDiseases,
                    ReleasedInMainGroup = view.ReleasedInMainGroup,
                    DisabilityCountDay = view.DisabilityCountDay,
                    Diagnosis = view.Diagnosis,
                    DrugTherapy = view.DrugTherapy,
                    PhysiotherapyTreatment = view.PhysiotherapyTreatment,
                    Other = view.Other,
                    DisabilityTypeId = (int)view.DisabilityType,
                    PatientId = view.PatientId,
                    MRIs = view.MRIs.ViewToEntity(),
                    HeartUltrasounds = view.HeartUltrasounds.ViewToEntity() ?? new List<HeartUltrasound>()
                };
            }

            return null;
        }

        public static List<InjuriesDiseases> ViewToEntity(this IEnumerable<InjuriesDiseasesView> views)
        {
            return views?.Select(t => t.ViewToEntity()).ToList();
        }

        public static InjuriesDiseasesView EntityToView(this InjuriesDiseases entity)
        {
            if (entity != null)
            {
                return new InjuriesDiseasesView
                {
                    Id = entity.Id,
                    DateInjuriesOrDiseases = entity.DateInjuriesOrDiseases,
                    ReleasedInMainGroup = entity.ReleasedInMainGroup,
                    DisabilityCountDay = entity.DisabilityCountDay,
                    Diagnosis = entity.Diagnosis,
                    DrugTherapy = entity.DrugTherapy,
                    PhysiotherapyTreatment = entity.PhysiotherapyTreatment,
                    Other = entity.Other,
                    DisabilityType = (Enums.DisabilityType)entity.DisabilityTypeId,
                    PatientId = entity.PatientId,
                    MRIs = entity.MRIs.EntityToView(),
                    HeartUltrasounds = entity.HeartUltrasounds.EntityToView() ?? new List<HeartUltrasoundView>()
                };
            }

            return null;
        }

        public static List<InjuriesDiseasesView> EntityToView(this IEnumerable<InjuriesDiseases> entities)
        {
            return entities?.Select(t => t.EntityToView()).ToList() ?? new List<InjuriesDiseasesView>();
        }
    }
}
