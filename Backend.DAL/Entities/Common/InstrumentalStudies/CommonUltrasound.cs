using Backend.DAL.Entities.InjuriesDiseasesEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Backend.DAL.Entities.Common.InstrumentalStudies
{
    public class CommonUltrasound : BaseEntity
    {
        public string Info { get; set; }
        public int InjuriesDiseasesId { get; set; }
        public InjuriesDiseases InjuriesDiseases { get; set; }

    }
}
