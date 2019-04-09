using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Views.InjuriesDiseasesEntities
{
    public class DisabilityTypeView
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
