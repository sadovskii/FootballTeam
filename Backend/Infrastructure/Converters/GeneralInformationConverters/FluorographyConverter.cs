using Backend.DAL.Entities.GeneralInformationEntities;
using Backend.Views.GeneralInformationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Converters.GeneralInformationConverters
{
    internal static class FluorographyConverter
    {
        public static Fluorography ViewToEntity(this FluorographyView view)
        {
            return new Fluorography
            {
                Id = view.Id,
                ProcedureTime = view.ProcedureTime,
                Information = view.Information,
                GeneralInformationId = view.GeneralInformationId
            };
        }

        public static List<Fluorography> ViewToEntity(this IEnumerable<FluorographyView> views)
        {
            return views.Select(t => t.ViewToEntity()).ToList();
        }

        public static FluorographyView EntityToView(this Fluorography entity)
        {
            return new FluorographyView
            {
                Id = entity.Id,
                ProcedureTime = entity.ProcedureTime,
                Information = entity.Information,
                GeneralInformationId = entity.GeneralInformationId
            };
        }

        public static List<FluorographyView> EntityToView(this IEnumerable<Fluorography> entities)
        {
            var a = entities.Select(t => t.EntityToView());
            return a.ToList();
        }
    }
}
