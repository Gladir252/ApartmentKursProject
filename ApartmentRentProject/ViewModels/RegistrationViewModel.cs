using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentRentProject.ViewModels
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "First name cannot be empty.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name cannot be empty.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email cannot be empty.")]
        [EmailAddress(ErrorMessage = "Incorrect email address.")]
        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect entry format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password cannot be empty.")]
        public string Password { get; set; }
    }
}
