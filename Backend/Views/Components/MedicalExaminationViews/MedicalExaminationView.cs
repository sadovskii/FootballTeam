using Backend.Views.Common.InstrumentalStudies.Components;
using Backend.Views.Common.LaboratoryResearch.Components;
using Backend.Views.Components;
using System;
using System.Collections.Generic;

namespace Backend.Views.MedicalExaminationEntities.Components
{
    public class MedicalExaminationView
    {
        public int Id { get; set; }
        public DateTime ProcedureTime { get; set; }
        public bool Allowance { get; set; }
        public int PatientId { get; set; }

        public ICollection<DoctorsDiagnosisView> DoctorsDiagnoses { get; set; }
        public ICollection<BloodChemistryAnalysisView> BloodChemistryAnalyses { get; set; }
        public ICollection<GeneralBloodAnalysisView> GeneralBloodAnalyses { get; set; }
        public ICollection<GeneralUrineAnalysisView> GeneralUrineAnalyses { get; set; }
        public ICollection<HeartUltrasoundView> HeartUltrasounds { get; set; }
        public ICollection<ElectrocardiogramView> Electrocardiograms { get; set; }

    }
}
