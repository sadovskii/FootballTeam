using Backend.DAL.Entities.GeneralInformationEntities;
using Backend.DAL.Entities.InjuriesDiseasesEntities;
using Backend.DAL.Entities.MedicalExaminationEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Backend.DAL.Entities
{
    public class Patient : BaseEntity
    {
        public string Name { get; set; }
        public string Photo { get; set; }

        public GeneralInformation GeneralInformation { get; set; }
        public ICollection<MedicalExamination> MedicalExaminations { get; set; }
        public ICollection<InjuriesDiseases> InjuriesDiseases { get; set; }
    }
}
