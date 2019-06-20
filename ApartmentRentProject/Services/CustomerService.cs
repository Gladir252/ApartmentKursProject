using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentRentProject.Interfaces;
using ApartmentRentProject.Models;
using ApartmentRentProject.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ApartmentRentProject.Services
{
    public class CustomerService : ICustomer
    {
        private readonly ApartmentDataBaseContext _apartmentContext;

        public CustomerService(ApartmentDataBaseContext apartmentContext)
        {
            _apartmentContext = apartmentContext;
        }

        public async Task<string> RegistrationAsync(RegistrationViewModel registrationViewModel)
        {
            if (registrationViewModel == null 
                || await _apartmentContext.User.FirstOrDefaultAsync(e => e.Email == registrationViewModel.Email)!= null)
            {
                return null;
            }

            PasswordHasher hasher = new PasswordHasher(registrationViewModel.Password);

            User user = new User
            {
                Email = registrationViewModel.Email,
                PasswordHash = hasher.GetHash(),
                LastName = registrationViewModel.LastName,
                FirstName = registrationViewModel.FirstName,
                Active = true,
                Role = "user"
            };
            await Task.Run(() => _apartmentContext.User.Add(user));
            Task.WaitAll();
            await Task.Run(() => _apartmentContext.SaveChangesAsync());

            return new JwtCreater(user.Email, user.Role).GetJwt();
        }

        public async Task<string> LoginAsync(LoginViewModel userViewModel)
        {
            if (userViewModel == null)
            {
                return null;
            }

            var currentUser = await _apartmentContext.User.FirstOrDefaultAsync(e => e.Email == userViewModel.Email && e.PasswordHash == new PasswordHasher(userViewModel.Password).GetHash());

            if (currentUser == null)
            {
                return null;
            }

            return new JwtCreater(currentUser.Email, currentUser.Role).GetJwt();
        }

        public async Task<bool> MakeOrderAsync(string email, List<int> productId)
        {
            Order order = new Order
            {
                Date = DateTime.Now,
                StatusId = 1,
                UserId = _apartmentContext.User.FirstOrDefaultAsync(e=>e.Email==email).Result.Id,
                Number = "Number"
            };
            var result = await _apartmentContext.Order.AddAsync(order);

            foreach (var id in productId)
            {
                await _apartmentContext.OrderProduct.AddAsync(new OrderProduct
                {
                    OrderId = result.Entity.Id,
                    ProductId = id
                });
            }

            return true;
        }
    }
}
