﻿using Backend.Views.Base;
using System;

namespace Backend.Views.GeneralInformationEntities.Components
{
    public class FluorographyView : BaseResponse
    {
        public int Id { get; set; }
        public DateTime ProcedureTime { get; set; }
        public string Information { get; set; }

        public int GeneralInformationId { get; set; }
        public GeneralInformationView GeneralInformation { get; set; }
    }
}
