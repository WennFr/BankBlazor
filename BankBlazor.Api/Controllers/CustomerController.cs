using BankBlazor.Api.DTOs;
using BankBlazor.ServiceLibrary.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankBlazor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerReadDto>> GetCustomer(int id)
        {
            var customerInfo = await _customerService.GetCustomerById(id);

            if (customerInfo == null)
            {
                return NotFound();
            }

            var customerReadDto = new CustomerReadDto
            {
                CustomerId = customerInfo.CustomerId,
                Givenname = customerInfo.Givenname,
                Surname = customerInfo.Surname,
                Streetaddress = customerInfo.Streetaddress,
                City = customerInfo.City,
                Zipcode = customerInfo.Zipcode,
                Country = customerInfo.Country,
                CountryCode = customerInfo.CountryCode,
                Birthday = customerInfo.Birthday.Value.ToDateTime(TimeOnly.MinValue),
                Telephonecountrycode = customerInfo.Telephonecountrycode,
                Telephonenumber = customerInfo.Telephonenumber,
                Emailaddress = customerInfo.Emailaddress
            };

            return Ok(customerReadDto);
        }
    }
}
