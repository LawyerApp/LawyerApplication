﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerApp.Areas.LawyerAdminPanel.Models
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
