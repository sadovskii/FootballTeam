using Backend.Views.InjuriesDiseasesEntities;
using System.ComponentModel.DataAnnotations;

namespace Backend.Views.Common.InstrumentalStudies
{
    public class MRIView
    {
        public int Id { get; set; }
        public string Info { get; set; }

        public int InjuriesDiseasesId { get; set; }
        public InjuriesDiseasesView InjuriesDiseases { get; set; }
    }
}
