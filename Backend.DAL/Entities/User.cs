﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.DAL.Entities
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}
