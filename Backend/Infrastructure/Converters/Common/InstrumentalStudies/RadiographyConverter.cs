using Backend.DAL.Entities.Common.InstrumentalStudies;
using Backend.Views.Components.Common.InstrumentalStudies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Converters.Common.InstrumentalStudies
{
    internal static class RadiographyConverter
    {
        public static Radiography ViewToEntity(this RadiographyView view)
        {
            if (view != null)
            {
                return new Radiography
                {
                    Id = view.Id,
                    Info = view.Info,
                    InjuriesDiseasesId = view.InjuriesDiseasesId
                };
            }

            return null;
        }

        public static List<Radiography> ViewToEntity(this IEnumerable<RadiographyView> views)
        {
            return views?.Select(t => t.ViewToEntity()).ToList();
        }

        public static RadiographyView EntityToView(this Radiography entity)
        {
            if (entity != null)
            {
                return new RadiographyView
                {
                    Id = entity.Id,
                    Info = entity.Info,
                    InjuriesDiseasesId = entity.InjuriesDiseasesId
                };
            }

            return null;
        }

        public static List<RadiographyView> EntityToView(this IEnumerable<Radiography> entities)
        {
            return entities?.Select(t => t.EntityToView()).ToList() ?? new List<RadiographyView>();
        }
    }
}
