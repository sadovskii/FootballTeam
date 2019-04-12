using Backend.DAL.Entities.Common.LaboratoryResearch;
using Backend.Infrastructure.Converters.MedicalExaminationConverters;
using Backend.Views.Common.LaboratoryResearch.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Converters.Common.LaboratoryResearch
{
    internal static class GeneralUrineAnalysisConverter
    {
        public static GeneralUrineAnalysis ViewToEntity(this GeneralUrineAnalysisView view)
        {
            if (view != null)
            {
                return new GeneralUrineAnalysis
                {
                    Id = view.Id,
                    Info = view.Info,
                    MedicalExaminationId = view.MedicalExaminationId
                };
            }

            return null;
        }

        public static List<GeneralUrineAnalysis> ViewToEntity(this IEnumerable<GeneralUrineAnalysisView> views)
        {
            return views?.Select(t => t.ViewToEntity()).ToList();
        }

        public static GeneralUrineAnalysisView EntityToView(this GeneralUrineAnalysis entity)
        {
            if (entity != null)
            {
                return new GeneralUrineAnalysisView
                {
                    Id = entity.Id,
                    Info = entity.Info,
                    MedicalExaminationId = entity.MedicalExaminationId
                };
            }

            return null;
        }

        public static List<GeneralUrineAnalysisView> EntityToView(this IEnumerable<GeneralUrineAnalysis> entities)
        {
            return entities?.Select(t => t.EntityToView()).ToList() ?? new List<GeneralUrineAnalysisView>();
        }
    }
}
