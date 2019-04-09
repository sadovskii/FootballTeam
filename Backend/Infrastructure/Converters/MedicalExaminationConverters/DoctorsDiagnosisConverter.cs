using Backend.DAL.Entities.MedicalExaminationEntities;
using Backend.Views.MedicalExaminationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Converters.MedicalExaminationConverters
{
    internal static class DoctorsDiagnosisConverter
    {
        public static DoctorsDiagnosis ViewToEntity(this DoctorsDiagnosisView patientView)
        {
            return new DoctorsDiagnosis
            {
                //Id = patientView.Id,
                //Name = patientView.Name,
                //Photo = patientView.Photo,
                //GeneralInformation = patientView.GeneralInformation,
                //InjuriesDiseases = patientView.InjuriesDiseases,
                //MedicalExaminations = patientView.MedicalExaminations
            };
        }

        public static List<DoctorsDiagnosis> ViewToEntity(this IEnumerable<DoctorsDiagnosisView> PatientViews)
        {
            return PatientViews.Select(t => t.ViewToEntity()).ToList();
        }

        public static DoctorsDiagnosisView EntityToView(this DoctorsDiagnosis WordsAndTranslationPair)
        {
            return new DoctorsDiagnosisView
            {
                //Id = WordsAndTranslationPair.Id,
                //Name = WordsAndTranslationPair.Name,
                //Photo = WordsAndTranslationPair.Photo,
                //GeneralInformation = WordsAndTranslationPair.GeneralInformation,
                //InjuriesDiseases = WordsAndTranslationPair.InjuriesDiseases,
                //MedicalExaminations = WordsAndTranslationPair.MedicalExaminations
            };
        }

        public static List<DoctorsDiagnosisView> EntityToView(this IEnumerable<DoctorsDiagnosis> Patients)
        {
            var a = Patients.Select(t => t.EntityToView());
            return a.ToList();
        }
    }
}
