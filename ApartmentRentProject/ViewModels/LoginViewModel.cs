﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentRentProject.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email cannot be empty.")]
        [EmailAddress(ErrorMessage = "Incorrect email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password cannot be empty.")]
        public string Password { get; set; }
    }
}
