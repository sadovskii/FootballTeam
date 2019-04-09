using Backend.DAL.Entities.Common.LaboratoryResearch;
using Backend.Views.Common.LaboratoryResearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Infrastructure.Converters.MedicalExaminationConverters;

namespace Backend.Infrastructure.Converters.Common.LaboratoryResearch
{
    internal static class BloodChemistryAnalysisConverter
    {
        public static BloodChemistryAnalysis ViewToEntity(this BloodChemistryAnalysisView view)
        {
            return new BloodChemistryAnalysis
            {
                Id = view.Id,
                Info = view.Info,
                MedicalExaminationId = view.MedicalExaminationId,
                MedicalExamination = view.MedicalExamination.ViewToEntity()
            };
        }

        public static List<BloodChemistryAnalysis> ViewToEntity(this IEnumerable<BloodChemistryAnalysisView> views)
        {
            return views.Select(t => t.ViewToEntity()).ToList();
        }

        public static BloodChemistryAnalysisView EntityToView(this BloodChemistryAnalysis entity)
        {
            return new BloodChemistryAnalysisView
            {
                Id = entity.Id,
                Info = entity.Info,
                MedicalExaminationId = entity.MedicalExaminationId,
                MedicalExamination = entity.MedicalExamination.EntityToView()
            };
        }

        public static List<BloodChemistryAnalysisView> EntityToView(this IEnumerable<BloodChemistryAnalysis> entities)
        {
            var a = entities.Select(t => t.EntityToView());
            return a.ToList();
        }
    }
}
