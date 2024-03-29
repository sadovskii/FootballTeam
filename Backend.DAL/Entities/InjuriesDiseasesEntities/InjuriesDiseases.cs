﻿using Backend.DAL.Entities.Common.InstrumentalStudies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.DAL.Entities.InjuriesDiseasesEntities
{
    public class InjuriesDiseases : BaseEntity
    {
        public InjuriesDiseases()
        {
            this.MRIs = new HashSet<MRI>();
            this.CommonUltrasounds = new List<CommonUltrasound>();
            this.Radiographies = new List<Radiography>();
        }

        public DateTime DateInjuriesOrDiseases { get; set; }
        public DateTime ReleasedInMainGroup { get; set; }
        public int DisabilityCountDay { get; set; }
        public string Diagnosis { get; set; }
        public string DrugTherapy { get; set; }
        public string PhysiotherapyTreatment { get; set; }
        public string Other { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DisabilityTypeId { get; set; }
        public DisabilityType DisabilityType { get; set; }
        public ICollection<MRI> MRIs { get; set; }
        public ICollection<CommonUltrasound> CommonUltrasounds { get; set; }
        public ICollection<Radiography> Radiographies { get; set; }


    }
}