using Backend.DAL.Entities;
using Backend.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Converters
{
    internal static class PatientConverter
    {
        public static Patient ViewToEntity(this PatientView patientView)
        {
            return new Patient
            {
                Id = patientView.Id,
                Name = patientView.Name,
                Photo = patientView.Photo,
                //GeneralInformation = patientView.GeneralInformation,
                //InjuriesDiseases = patientView.InjuriesDiseases,
                //MedicalExaminations = patientView.MedicalExaminations
            };
        }

        public static List<Patient> ViewToEntity(this IEnumerable<PatientView> PatientViews)
        {
            return PatientViews.Select(t => t.ViewToEntity()).ToList();
        }

        public static PatientView EntityToView(this Patient WordsAndTranslationPair)
        {
            return new PatientView
            {
                Id = WordsAndTranslationPair.Id,
                Name = WordsAndTranslationPair.Name,
                Photo = WordsAndTranslationPair.Photo,
                //GeneralInformation = WordsAndTranslationPair.GeneralInformation,
                //InjuriesDiseases = WordsAndTranslationPair.InjuriesDiseases,
                //MedicalExaminations = WordsAndTranslationPair.MedicalExaminations
            };
        }

        public static List<PatientView> EntityToView(this IEnumerable<Patient> Patients)
        {
            var a = Patients.Select(t => t.EntityToView());
            return a.ToList();
        }
    }
}
