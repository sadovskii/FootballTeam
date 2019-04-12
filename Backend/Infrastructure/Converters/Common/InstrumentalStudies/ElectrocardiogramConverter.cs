using Backend.DAL.Entities.Common.InstrumentalStudies;
using Backend.Views.Common.InstrumentalStudies.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Infrastructure.Converters.MedicalExaminationConverters;

namespace Backend.Infrastructure.Converters.Common.InstrumentalStudies
{
    internal static class ElectrocardiogramConverter
    {
        public static Electrocardiogram ViewToEntity(this ElectrocardiogramView view)
        {
            if (view != null)
            {
                return new Electrocardiogram
                {
                    Id = view.Id,
                    Info = view.Info,
                    MedicalExaminationId = view.MedicalExaminationId
                };
            }

            return null;

        }

        public static List<Electrocardiogram> ViewToEntity(this IEnumerable<ElectrocardiogramView> views)
        {
            return views?.Select(t => t.ViewToEntity()).ToList();
        }

        public static ElectrocardiogramView EntityToView(this Electrocardiogram entity)
        {
            if (entity != null)
            {
                return new ElectrocardiogramView
                {
                    Id = entity.Id,
                    Info = entity.Info,
                    MedicalExaminationId = entity.MedicalExaminationId
                };
            }

            return null;
        }

        public static List<ElectrocardiogramView> EntityToView(this IEnumerable<Electrocardiogram> entities)
        {
            return entities.Select(t => t.EntityToView()).ToList() ?? new List<ElectrocardiogramView>();
        }
    }
}
