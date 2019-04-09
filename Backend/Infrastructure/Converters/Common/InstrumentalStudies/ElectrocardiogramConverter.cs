using Backend.DAL.Entities.Common.InstrumentalStudies;
using Backend.Views.Common.InstrumentalStudies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Converters.Common.InstrumentalStudies
{
    internal static class ElectrocardiogramConverter
    {
        public static Electrocardiogram ViewToEntity(this ElectrocardiogramView view)
        {
            return new Electrocardiogram
            {
                Id = view.Id,
                Info = view.Info,
                MedicalExaminationId = view.MedicalExaminationId,
                //MedicalExamination = view.MedicalExamination,
            };
        }

        public static List<Electrocardiogram> ViewToEntity(this IEnumerable<ElectrocardiogramView> views)
        {
            return views.Select(t => t.ViewToEntity()).ToList();
        }

        public static ElectrocardiogramView EntityToView(this Electrocardiogram entity)
        {
            return new ElectrocardiogramView
            {
                Id = entity.Id,
                Info = entity.Info,
                MedicalExaminationId = entity.MedicalExaminationId,
                //MedicalExamination = entity.MedicalExamination,
            };
        }

        public static List<ElectrocardiogramView> EntityToView(this IEnumerable<Electrocardiogram> entities)
        {
            var a = entities.Select(t => t.EntityToView());
            return a.ToList();
        }
    }
}
