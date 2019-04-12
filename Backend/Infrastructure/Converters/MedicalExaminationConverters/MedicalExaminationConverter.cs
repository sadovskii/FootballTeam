using Backend.DAL.Entities.MedicalExaminationEntities;
using Backend.Views.MedicalExaminationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DAL.Entities.Common.InstrumentalStudies;
using Backend.DAL.Entities.Common.LaboratoryResearch;
using Backend.Infrastructure.Converters.Common.InstrumentalStudies;
using Backend.Infrastructure.Converters.Common.LaboratoryResearch;
using Backend.Views.Common.InstrumentalStudies.Components;
using Backend.Views.Common.LaboratoryResearch.Components;
using Backend.Views.MedicalExaminationEntities.Components;

namespace Backend.Infrastructure.Converters.MedicalExaminationConverters
{
    internal static class MedicalExaminationConverter
    {
        public static MedicalExamination ViewToEntity(this MedicalExaminationView view)
        {
            if (view != null)
            {
                return new MedicalExamination
                {
                    Id = view.Id,
                    ProcedureTime = view.ProcedureTime,
                    Allowance = view.Allowance,
                    PatientId = view.PatientId
                };
            }

            return null;
        }

        public static List<MedicalExamination> ViewToEntity(this IEnumerable<MedicalExaminationView> views)
        {
            return views?.Select(t => t.ViewToEntity()).ToList();
        }

        public static MedicalExaminationView EntityToView(this MedicalExamination entity)
        {
            if (entity != null)
            {
                return new MedicalExaminationView
                {
                    Id = entity.Id,
                    ProcedureTime = entity.ProcedureTime,
                    Allowance = entity.Allowance,
                    PatientId = entity.PatientId
                };
            }

            return null;
        }

        public static List<MedicalExaminationView> EntityToView(this IEnumerable<MedicalExamination> entities)
        {
            return entities?.Select(t => t.EntityToView()).ToList() ?? new List<MedicalExaminationView>();
        }
    }
}
