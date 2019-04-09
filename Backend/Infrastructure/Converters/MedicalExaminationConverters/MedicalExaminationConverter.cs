using Backend.DAL.Entities.MedicalExaminationEntities;
using Backend.Views.MedicalExaminationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Converters.MedicalExaminationConverters
{
    internal static class MedicalExaminationConverter
    {
        public static MedicalExamination ViewToEntity(this MedicalExaminationView view)
        {
            return new MedicalExamination
            {
                Id = view.Id,
                ProcedureTime = view.ProcedureTime,
                Allowance = view.Allowance,
                PatientId = view.PatientId,
                //DoctorsDiagnoses = view.DoctorsDiagnoses,
                //BloodChemistryAnalyses = view.BloodChemistryAnalyses,
                //GeneralBloodAnalyses = view.GeneralBloodAnalyses,
                //GeneralUrineAnalyses = view.GeneralUrineAnalyses,
                //HeartUltrasounds = view.HeartUltrasounds,
                //Electrocardiograms = view.Electrocardiograms
            };
        }

        public static List<MedicalExamination> ViewToEntity(this IEnumerable<MedicalExaminationView> views)
        {
            return views.Select(t => t.ViewToEntity()).ToList();
        }

        public static MedicalExaminationView EntityToView(this MedicalExamination entity)
        {
            return new MedicalExaminationView
            {
                Id = entity.Id,
                ProcedureTime = entity.ProcedureTime,
                Allowance = entity.Allowance,
                PatientId = entity.PatientId,
                //DoctorsDiagnoses = entity.DoctorsDiagnoses,
                //BloodChemistryAnalyses = entity.BloodChemistryAnalyses,
                //GeneralBloodAnalyses = entity.GeneralBloodAnalyses,
                //GeneralUrineAnalyses = entity.GeneralUrineAnalyses,
                //HeartUltrasounds = entity.HeartUltrasounds,
                //Electrocardiograms = entity.Electrocardiograms
            };
        }

        public static List<MedicalExaminationView> EntityToView(this IEnumerable<MedicalExamination> entities)
        {
            var a = entities.Select(t => t.EntityToView());
            return a.ToList();
        }
    }
}
