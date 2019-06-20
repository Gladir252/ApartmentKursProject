using ApartmentRentProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentRentProject.Interfaces
{
    public interface ICustomer
    {
        Task<string> RegistrationAsync(RegistrationViewModel model);
        Task<string> LoginAsync(LoginViewModel model);
    }
}
