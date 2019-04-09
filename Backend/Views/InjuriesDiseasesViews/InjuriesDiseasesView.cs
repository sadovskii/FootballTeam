using Backend.Views.Common.InstrumentalStudies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Views.InjuriesDiseasesEntities
{
    public class InjuriesDiseasesView
    {
        [Key]
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
        public DisabilityTypeView DisabilityType { get; set; }
        public ICollection<MRIView> MRIs { get; set; }
        public ICollection<HeartUltrasoundView> HeartUltrasounds { get; set; }


    }
}