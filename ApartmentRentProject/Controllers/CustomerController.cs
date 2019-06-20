using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApartmentRentProject.Interfaces;
using ApartmentRentProject.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentRentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customerService;

        public CustomerController(ICustomer customerService)
        {
            _customerService = customerService;
        }

        [HttpPost, Route("/register")]
        public async Task<IActionResult> RegisterUserAsyncTask([FromBody] RegistrationViewModel model)
        {
            var result = await _customerService.RegistrationAsync(model);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Bad request!");
            }
        }

        [HttpPut, Route("/login")]
        public async Task<IActionResult> LoginUserAsyncTask([FromBody] LoginViewModel model)
        {
            var result = await _customerService.LoginAsync(model);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Bad request!");
            }
        }

        [HttpPost, Route("/make-order")]
        public async Task<IActionResult> MakeOrderAsyncTask([FromBody]List<int> productList)
        {
            if (await _customerService.MakeOrderAsync(User.FindFirstValue(ClaimTypes.Email), productList))
            {
                return Ok("Successfuly made!");
            }
            else
            {
                return BadRequest("Bad request!");
            }
        }

    }
}