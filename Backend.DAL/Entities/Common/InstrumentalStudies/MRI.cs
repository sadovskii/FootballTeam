using Backend.DAL.Entities.InjuriesDiseasesEntities;
using System.ComponentModel.DataAnnotations;

namespace Backend.DAL.Entities.Common.InstrumentalStudies
{
    public class MRI : BaseEntity
    {
        public string Info { get; set; }

        public int InjuriesDiseasesId { get; set; }
        public InjuriesDiseases InjuriesDiseases { get; set; }
    }
}
