using Backend.Views.Common.InstrumentalStudies;
using Backend.Views.Common.LaboratoryResearch;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Backend.Views.MedicalExaminationEntities
{
    public class MedicalExaminationView
    {
        [Key]
        public int Id { get; set; }
        public DateTime ProcedureTime { get; set; }
        public bool Allowance { get; set; }

        public ICollection<DoctorsDiagnosisView> DoctorsDiagnoses { get; set; }
        public ICollection<BloodChemistryAnalysisView> BloodChemistryAnalyses { get; set; }
        public ICollection<GeneralBloodAnalysisView> GeneralBloodAnalyses { get; set; }
        public ICollection<GeneralUrineAnalysisView> GeneralUrineAnalyses { get; set; }
        public ICollection<HeartUltrasoundView> HeartUltrasounds { get; set; }
        public ICollection<ElectrocardiogramView> Electrocardiograms { get; set; }

        public int PatientId { get; set; }
        public PatientView Patient { get; set; }

    }
}
