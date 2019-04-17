using Backend.DAL.Entities.Common.InstrumentalStudies;
using Backend.Views.Components.Common.InstrumentalStudies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Converters.Common.InstrumentalStudies
{
    internal static class CommonUltrasoundConverter
    {
        public static CommonUltrasound ViewToEntity(this CommonUltrasoundView view)
        {
            if (view != null)
            {
                return new CommonUltrasound
                {
                    Id = view.Id,
                    Info = view.Info,
                    InjuriesDiseasesId = view.InjuriesDiseasesId
                };
            }

            return null;
        }

        public static List<CommonUltrasound> ViewToEntity(this IEnumerable<CommonUltrasoundView> views)
        {
            return views?.Select(t => t.ViewToEntity()).ToList();
        }

        public static CommonUltrasoundView EntityToView(this CommonUltrasound entity)
        {
            if (entity != null)
            {
                return new CommonUltrasoundView
                {
                    Id = entity.Id,
                    Info = entity.Info,
                    InjuriesDiseasesId = entity.InjuriesDiseasesId
                };
            }

            return null;

        }

        public static List<CommonUltrasoundView> EntityToView(this IEnumerable<CommonUltrasound> entities)
        {
            return entities?.Select(t => t.EntityToView()).ToList() ?? new List<CommonUltrasoundView>();
        }
    }
}
