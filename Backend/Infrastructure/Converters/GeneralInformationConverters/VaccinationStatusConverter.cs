using Backend.DAL.Entities.GeneralInformationEntities;
using Backend.Views.GeneralInformationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Converters.GeneralInformationConverters
{
    internal static class VaccinationStatusConverter
    {
        public static VaccinationStatus ViewToEntity(this VaccinationStatusView view)
        {
            return new VaccinationStatus
            {
                Id = view.Id,
                ProcedureTime = view.ProcedureTime,
                Information = view.Information,
                GeneralInformationId = view.GeneralInformationId
            };
        }

        public static List<VaccinationStatus> ViewToEntity(this IEnumerable<VaccinationStatusView> views)
        {
            return views.Select(t => t.ViewToEntity()).ToList();
        }

        public static VaccinationStatusView EntityToView(this VaccinationStatus entity)
        {
            return new VaccinationStatusView
            {
                Id = entity.Id,
                ProcedureTime = entity.ProcedureTime,
                Information = entity.Information,
                GeneralInformationId = entity.GeneralInformationId
            };
        }

        public static List<VaccinationStatusView> EntityToView(this IEnumerable<VaccinationStatus> entities)
        {
            var a = entities.Select(t => t.EntityToView());
            return a.ToList();
        }
    }
}
