using Backend.DAL.Entities.Common.InstrumentalStudies;
using Backend.DAL.Entities.Common.LaboratoryResearch;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Backend.DAL.Entities.MedicalExaminationEntities
{
    public class MedicalExamination : BaseEntity
    {
        public MedicalExamination()
        {
            this.DoctorsDiagnoses = new HashSet<DoctorsDiagnosis>();
            this.BloodChemistryAnalyses = new List<BloodChemistryAnalysis>();
            this.GeneralBloodAnalyses = new List<GeneralBloodAnalysis>();
            this.GeneralUrineAnalyses = new List<GeneralUrineAnalysis>();
            this.HeartUltrasounds = new List<HeartUltrasound>();
            this.Electrocardiograms = new List<Electrocardiogram>();
        }


        public DateTime ProcedureTime { get; set; }
        public bool Allowance { get; set; }

        public ICollection<DoctorsDiagnosis> DoctorsDiagnoses { get; set; }
        public ICollection<BloodChemistryAnalysis> BloodChemistryAnalyses { get; set; }
        public ICollection<GeneralBloodAnalysis> GeneralBloodAnalyses { get; set; }
        public ICollection<GeneralUrineAnalysis> GeneralUrineAnalyses { get; set; }
        public ICollection<HeartUltrasound> HeartUltrasounds { get; set; }
        public ICollection<Electrocardiogram> Electrocardiograms { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

    }
}
