using ApartmentRentProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentRentProject.Services
{
    public class AdminService
    {
        private readonly ApartmentDataBaseContext _apartmentContext;

        public AdminService(ApartmentDataBaseContext apartmentContext)
        {
            _apartmentContext = apartmentContext;
        }

        public async Task<string> EditProductAsync(Product product)
        {
            return null;
        }

        public async Task<string> DeacriveUserAsync(string email)
        {
            return null;
        }
    }
}
