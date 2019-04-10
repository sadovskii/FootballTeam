using Backend.DAL.Entities;
using Backend.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DAL.Entities.InjuriesDiseasesEntities;
using Backend.DAL.Entities.MedicalExaminationEntities;
using Backend.Infrastructure.Converters.GeneralInformationConverters;
using Backend.Infrastructure.Converters.InjuriesDiseasesConverters;
using Backend.Infrastructure.Converters.MedicalExaminationConverters;
using Backend.Views.InjuriesDiseasesEntities;
using Backend.Views.MedicalExaminationEntities;
using Microsoft.CodeAnalysis.Emit;

namespace Backend.Infrastructure.Converters
{
    internal static class PatientConverter
    {
        public static Patient ViewToEntity(this PatientView view)
        {
            if (view != null)
            {
                return new Patient
                {
                    Id = view.Id,
                    Name = view.Name,
                    Photo = view.Photo,
                    GeneralInformation = view.GeneralInformation.ViewToEntity(),
                    InjuriesDiseases = view.InjuriesDiseases.ViewToEntity() ?? new List<InjuriesDiseases>(),
                    MedicalExaminations = view.MedicalExaminations.ViewToEntity() ?? new List<MedicalExamination>()
                };
            }

            return null;
        }

        public static List<Patient> ViewToEntity(this IEnumerable<PatientView> views)
        {
            if (views != null)
                return views.Select(t => t.ViewToEntity()).ToList();
            
            return new List<Patient>();
        }

        public static PatientView EntityToView(this Patient entity)
        {
            if (entity != null)
            {
                return new PatientView
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Photo = entity.Photo,
                    GeneralInformation = entity.GeneralInformation.EntityToView(),
                    InjuriesDiseases = entity.InjuriesDiseases.EntityToView() ?? new List<InjuriesDiseasesView>(),
                    MedicalExaminations = entity.MedicalExaminations.EntityToView() ?? new List<MedicalExaminationView>()
                };
            }

            return null;
        }

        public static List<PatientView> EntityToView(this IEnumerable<Patient> entities)
        {
            if (entities != null)
                return entities.Select(t => t.EntityToView()).ToList();
            
            return new List<PatientView>();
        }
    }
}
