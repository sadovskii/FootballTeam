﻿using Backend.DAL.Entities.InjuriesDiseasesEntities;
using Backend.Views.InjuriesDiseasesEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Converters.InjuriesDiseasesConverters
{
    internal static class InjuriesDiseasesConverter
    {
        public static InjuriesDiseases ViewToEntity(this InjuriesDiseasesView view)
        {
            return new InjuriesDiseases
            {
                Id = view.Id,
                DateInjuriesOrDiseases = view.DateInjuriesOrDiseases,
                ReleasedInMainGroup = view.ReleasedInMainGroup,
                DisabilityCountDay = view.DisabilityCountDay,
                Diagnosis = view.Diagnosis,
                DrugTherapy = view.DrugTherapy,
                PhysiotherapyTreatment = view.PhysiotherapyTreatment,
                Other = view.Other,
                PatientId = view.PatientId,
                //MRIs = view.MRIs,
                //HeartUltrasounds = view.HeartUltrasounds
            };
        }

        public static List<InjuriesDiseases> ViewToEntity(this IEnumerable<InjuriesDiseasesView> views)
        {
            return views.Select(t => t.ViewToEntity()).ToList();
        }

        public static InjuriesDiseasesView EntityToView(this InjuriesDiseases entity)
        {
            return new InjuriesDiseasesView
            {
                Id = entity.Id,
                DateInjuriesOrDiseases = entity.DateInjuriesOrDiseases,
                ReleasedInMainGroup = entity.ReleasedInMainGroup,
                DisabilityCountDay = entity.DisabilityCountDay,
                Diagnosis = entity.Diagnosis,
                DrugTherapy = entity.DrugTherapy,
                PhysiotherapyTreatment = entity.PhysiotherapyTreatment,
                Other = entity.Other,
                PatientId = entity.PatientId,
                //MRIs = entity.MRIs,
                //HeartUltrasounds = entity.HeartUltrasounds
            };
        }

        public static List<InjuriesDiseasesView> EntityToView(this IEnumerable<InjuriesDiseases> entities)
        {
            var a = entities.Select(t => t.EntityToView());
            return a.ToList();
        }
    }
}
