using Backend.Views.MedicalExaminationEntities.Components;
using Microsoft.AspNetCore.Http;

namespace Backend.Views.Common.LaboratoryResearch.Components
{
    public class BloodChemistryAnalysisView 
    { 
        public int Id { get; set; }
        public string Info { get; set; }
        public IFormFile File { get; set; }

        public int MedicalExaminationId { get; set; }
    }
}
