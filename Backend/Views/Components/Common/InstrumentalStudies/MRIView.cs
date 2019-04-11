﻿using Backend.Views.InjuriesDiseasesEntities.Components;

namespace Backend.Views.Common.InstrumentalStudies.Components
{
    public class MRIView
    {
        public int Id { get; set; }
        public string Info { get; set; }

        public int InjuriesDiseasesId { get; set; }
        public InjuriesDiseasesView InjuriesDiseases { get; set; }
    }
}
