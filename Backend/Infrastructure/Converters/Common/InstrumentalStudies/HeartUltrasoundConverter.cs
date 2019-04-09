using Backend.DAL.Entities.Common.InstrumentalStudies;
using Backend.Views.Common.InstrumentalStudies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Converters.Common.InstrumentalStudies
{
    internal static class HeartUltrasoundConverter
    {
        public static HeartUltrasound ViewToEntity(this HeartUltrasoundView view)
        {
            return new HeartUltrasound
            {
                Id = view.Id,
                Info = view.Info,
                MedicalExaminationId = view.MedicalExaminationId,
                //MedicalExamination = view.MedicalExamination
   
            };
        }

        public static List<HeartUltrasound> ViewToEntity(this IEnumerable<HeartUltrasoundView> views)
        {
            return views.Select(t => t.ViewToEntity()).ToList();
        }

        public static HeartUltrasoundView EntityToView(this HeartUltrasound entity)
        {
            return new HeartUltrasoundView
            {
                Id = entity.Id,
                Info = entity.Info,
                MedicalExaminationId = entity.MedicalExaminationId,
                //MedicalExamination = entity.MedicalExamination
            };
        }

        public static List<HeartUltrasoundView> EntityToView(this IEnumerable<HeartUltrasound> entities)
        {
            var a = entities.Select(t => t.EntityToView());
            return a.ToList();
        }
    }
}
