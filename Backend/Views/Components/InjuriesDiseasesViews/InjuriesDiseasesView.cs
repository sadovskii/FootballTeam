using Backend.Infrastructure.Enums;
using Backend.Views.Common.InstrumentalStudies.Components;
using Backend.Views.Components;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using Backend.Views.Components.Common.InstrumentalStudies;

namespace Backend.Views.InjuriesDiseasesEntities.Components
{
    public class InjuriesDiseasesView
    {
        public int Id { get; set; }
        public DateTime DateInjuriesOrDiseases { get; set; }
        public DateTime ReleasedInMainGroup { get; set; }
        public int DisabilityCountDay { get; set; }
        public string Diagnosis { get; set; }
        public string DrugTherapy { get; set; }
        public string PhysiotherapyTreatment { get; set; }
        public string Other { get; set; }

        public int PatientId { get; set; }
        public PatientView Patient { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public DisabilityType DisabilityType { get; set; }
        public ICollection<MRIView> MRIs { get; set; }
        public ICollection<CommonUltrasoundView> CommonUltrasounds { get; set; }
        public ICollection<RadiographyView> Radiographies { get; set; }


    }
}