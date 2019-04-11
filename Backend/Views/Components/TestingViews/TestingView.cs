using Backend.Views.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Backend.Views.TestingEntities.Components
{
    public class TestingView : BaseResponse
    {
        [Key]
        public int Id { get; set; }
    }
}
