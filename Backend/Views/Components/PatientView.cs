using Backend.Views.GeneralInformationEntities.Components;
using Backend.Views.InjuriesDiseasesEntities.Components;
using Backend.Views.MedicalExaminationEntities.Components;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Backend.Views.Components
{
    public class PatientView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public IFormFile File { get; set; }

        public GeneralInformationView GeneralInformation { get; set; }
        public ICollection<MedicalExaminationView> MedicalExaminations { get; set; }
        public ICollection<InjuriesDiseasesView> InjuriesDiseases { get; set; }
    }
}
