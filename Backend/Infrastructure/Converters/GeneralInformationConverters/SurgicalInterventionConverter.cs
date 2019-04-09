using Backend.DAL.Entities.GeneralInformationEntities;
using Backend.Views.GeneralInformationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Converters.GeneralInformationConverters
{
    internal static class SurgicalInterventionConverter
    {
        public static SurgicalIntervention ViewToEntity(this SurgicalInterventionView view)
        {
            return new SurgicalIntervention
            {
                Id = view.Id,
                ProcedureTime = view.ProcedureTime,
                Diagnosis = view.Diagnosis,
                InterventionType = view.InterventionType,
                GeneralInformationId = view.GeneralInformationId
            };
        }

        public static List<SurgicalIntervention> ViewToEntity(this IEnumerable<SurgicalInterventionView> views)
        {
            return views.Select(t => t.ViewToEntity()).ToList();
        }

        public static SurgicalInterventionView EntityToView(this SurgicalIntervention entity)
        {
            return new SurgicalInterventionView
            {
                Id = entity.Id,
                ProcedureTime = entity.ProcedureTime,
                Diagnosis = entity.Diagnosis,
                InterventionType = entity.InterventionType,
                GeneralInformationId = entity.GeneralInformationId
            };
        }

        public static List<SurgicalInterventionView> EntityToView(this IEnumerable<SurgicalIntervention> entities)
        {
            var a = entities.Select(t => t.EntityToView());
            return a.ToList();
        }
    }
}
