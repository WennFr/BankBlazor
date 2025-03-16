using BankBlazor.ServiceLibrary.Contexts;
using BankBlazor.ServiceLibrary.Entities;
using BankBlazor.ServiceLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBlazor.ServiceLibrary.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly BankBlazorContext _dbContext;

        public CustomerService(BankBlazorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            return await _dbContext.Customers.FindAsync(id);
        }   

    }
}
