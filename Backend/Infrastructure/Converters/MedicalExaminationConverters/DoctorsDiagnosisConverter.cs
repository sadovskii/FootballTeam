﻿using Backend.DAL.Entities.MedicalExaminationEntities;
using Backend.Views.MedicalExaminationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Converters.MedicalExaminationConverters
{
    internal static class DoctorsDiagnosisConverter
    {
        public static DoctorsDiagnosis ViewToEntity(this DoctorsDiagnosisView view)
        {
            return new DoctorsDiagnosis
            {
                Id = view.Id,
                Diagnosis = view.Diagnosis,
                MedicalExaminationId = view.MedicalExaminationId,
                MedicalProfessionId = view.MedicalProfessionId,
                MedicalProfession = view.MedicalProfession.ViewToEntity(),
                MedicalExamination = view.MedicalExamination
            };
        }

        public static List<DoctorsDiagnosis> ViewToEntity(this IEnumerable<DoctorsDiagnosisView> views)
        {
            return views.Select(t => t.ViewToEntity()).ToList();
        }

        public static DoctorsDiagnosisView EntityToView(this DoctorsDiagnosis entity)
        {
            return new DoctorsDiagnosisView
            {
                Id = entity.Id,
                Diagnosis = entity.Diagnosis,
                MedicalExaminationId = entity.MedicalExaminationId,
                MedicalProfessionId = entity.MedicalProfessionId,
                //MedicalProfession = entity.MedicalProfession,
                //MedicalExamination = entity.MedicalExamination
            };
        }

        public static List<DoctorsDiagnosisView> EntityToView(this IEnumerable<DoctorsDiagnosis> entities)
        {
            var a = entities.Select(t => t.EntityToView());
            return a.ToList();
        }
    }
}