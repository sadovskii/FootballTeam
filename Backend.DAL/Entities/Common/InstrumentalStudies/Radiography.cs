using Backend.DAL.Entities.InjuriesDiseasesEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.DAL.Entities.Common.InstrumentalStudies
{
    public class Radiography : BaseEntity
    {
        public string Info { get; set; }

        public int InjuriesDiseasesId { get; set; }
        public InjuriesDiseases InjuriesDiseases { get; set; }


    }
}
