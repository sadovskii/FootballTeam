using Backend.DAL.Entities.Common.LaboratoryResearch;
using Backend.Infrastructure.Converters.MedicalExaminationConverters;
using Backend.Views.Common.LaboratoryResearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Converters.Common.LaboratoryResearch
{
    internal static class GeneralBloodAnalysisConverter
    {
        public static GeneralBloodAnalysis ViewToEntity(this GeneralBloodAnalysisView view)
        {
            return new GeneralBloodAnalysis
            {
                Id = view.Id,
                Info = view.Info,
                MedicalExaminationId = view.MedicalExaminationId,
                MedicalExamination = view.MedicalExamination.ViewToEntity()
            };
        }

        public static List<GeneralBloodAnalysis> ViewToEntity(this IEnumerable<GeneralBloodAnalysisView> views)
        {
            return views.Select(t => t.ViewToEntity()).ToList();
        }

        public static GeneralBloodAnalysisView EntityToView(this GeneralBloodAnalysis entity)
        {
            return new GeneralBloodAnalysisView
            {
                Id = entity.Id,
                Info = entity.Info,
                MedicalExaminationId = entity.MedicalExaminationId,
                MedicalExamination = entity.MedicalExamination.EntityToView()
            };
        }

        public static List<GeneralBloodAnalysisView> EntityToView(this IEnumerable<GeneralBloodAnalysis> entities)
        {
            var a = entities.Select(t => t.EntityToView());
            return a.ToList();
        }
    }
}
