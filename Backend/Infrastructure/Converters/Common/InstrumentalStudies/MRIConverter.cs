using Backend.DAL.Entities.Common.InstrumentalStudies;
using Backend.Views.Common.InstrumentalStudies.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Infrastructure.Converters.InjuriesDiseasesConverters;

namespace Backend.Infrastructure.Converters.Common.InstrumentalStudies
{
    internal static class MRIConverter
    {
        public static MRI ViewToEntity(this MRIView view)
        {
            if (view != null)
            {
                return new MRI
                {
                    Id = view.Id,
                    Info = view.Info,
                    InjuriesDiseasesId = view.InjuriesDiseasesId,
                    InjuriesDiseases = view.InjuriesDiseases.ViewToEntity()
                };
            }

            return null;
        }

        public static List<MRI> ViewToEntity(this IEnumerable<MRIView> views)
        {
            return views?.Select(t => t.ViewToEntity()).ToList();
        }

        public static MRIView EntityToView(this MRI entity)
        {
            if (entity != null)
            {
                return new MRIView
                {
                    Id = entity.Id,
                    Info = entity.Info,
                    InjuriesDiseasesId = entity.InjuriesDiseasesId,
                    InjuriesDiseases = entity.InjuriesDiseases.EntityToView()
                };
            }

            return null;
        }

        public static List<MRIView> EntityToView(this IEnumerable<MRI> entities)
        {
            return entities?.Select(t => t.EntityToView()).ToList() ?? new List<MRIView>();
        }
    }
}
