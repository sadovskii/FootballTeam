using Backend.DAL.Entities.Common.InstrumentalStudies;
using Backend.Views.Common.InstrumentalStudies.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Infrastructure.Converters.MedicalExaminationConverters;

namespace Backend.Infrastructure.Converters.Common.InstrumentalStudies
{
    internal static class HeartUltrasoundConverter
    {
        public static HeartUltrasound ViewToEntity(this HeartUltrasoundView view)
        {
            if (view != null)
            {
                return new HeartUltrasound
                {
                    Id = view.Id,
                    Info = view.Info,
                    MedicalExaminationId = view.MedicalExaminationId
                };
            }

            return null;
        }

        public static List<HeartUltrasound> ViewToEntity(this IEnumerable<HeartUltrasoundView> views)
        {
            return views?.Select(t => t.ViewToEntity()).ToList();
        }

        public static HeartUltrasoundView EntityToView(this HeartUltrasound entity)
        {
            if (entity != null)
            {
                return new HeartUltrasoundView
                {
                    Id = entity.Id,
                    Info = entity.Info,
                    MedicalExaminationId = entity.MedicalExaminationId
                };
            }

            return null;

        }

        public static List<HeartUltrasoundView> EntityToView(this IEnumerable<HeartUltrasound> entities)
        {
            return entities?.Select(t => t.EntityToView()).ToList() ?? new List<HeartUltrasoundView>();
        }
    }
}
