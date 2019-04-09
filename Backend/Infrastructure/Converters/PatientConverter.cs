using Backend.DAL.Entities;
using Backend.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Infrastructure.Converters.GeneralInformationConverters;
using Backend.Infrastructure.Converters.InjuriesDiseasesConverters;
using Backend.Infrastructure.Converters.MedicalExaminationConverters;

namespace Backend.Infrastructure.Converters
{
    internal static class PatientConverter
    {
        public static Patient ViewToEntity(this PatientView view)
        {
            return new Patient
            {
                Id = view.Id,
                Name = view.Name,
                Photo = view.Photo,
                GeneralInformation = view.GeneralInformation.ViewToEntity(),
                InjuriesDiseases = view.InjuriesDiseases.ViewToEntity(),
                MedicalExaminations = view.MedicalExaminations.ViewToEntity()
            };
        }

        public static List<Patient> ViewToEntity(this IEnumerable<PatientView> views)
        {
            return views.Select(t => t.ViewToEntity()).ToList();
        }

        public static PatientView EntityToView(this Patient entity)
        {
            return new PatientView
            {
                Id = entity.Id,
                Name = entity.Name,
                Photo = entity.Photo,
                GeneralInformation = entity.GeneralInformation.EntityToView(),
                InjuriesDiseases = entity.InjuriesDiseases.EntityToView(),
                MedicalExaminations = entity.MedicalExaminations.EntityToView()
            };
        }

        public static List<PatientView> EntityToView(this IEnumerable<Patient> entities)
        {
            var a = entities.Select(t => t.EntityToView());
            return a.ToList();
        }
    }
}
