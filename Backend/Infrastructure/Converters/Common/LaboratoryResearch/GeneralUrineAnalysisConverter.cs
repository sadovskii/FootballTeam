using Backend.DAL.Entities.Common.LaboratoryResearch;
using Backend.Infrastructure.Converters.MedicalExaminationConverters;
using Backend.Views.Common.LaboratoryResearch;
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
            return new GeneralUrineAnalysis
            {
                Id = view.Id,
                Info = view.Info,
                MedicalExaminationId = view.MedicalExaminationId,
                MedicalExamination = view.MedicalExamination.ViewToEntity()
            };
        }

        public static List<GeneralUrineAnalysis> ViewToEntity(this IEnumerable<GeneralUrineAnalysisView> views)
        {
            return views.Select(t => t.ViewToEntity()).ToList();
        }

        public static GeneralUrineAnalysisView EntityToView(this GeneralUrineAnalysis entity)
        {
            return new GeneralUrineAnalysisView
            {
                Id = entity.Id,
                Info = entity.Info,
                MedicalExaminationId = entity.MedicalExaminationId,
                MedicalExamination = entity.MedicalExamination.EntityToView()
            };
        }

        public static List<GeneralUrineAnalysisView> EntityToView(this IEnumerable<GeneralUrineAnalysis> entities)
        {
            var a = entities.Select(t => t.EntityToView());
            return a.ToList();
        }
    }
}
