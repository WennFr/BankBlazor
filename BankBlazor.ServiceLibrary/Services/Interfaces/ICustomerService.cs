using BankBlazor.ServiceLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBlazor.ServiceLibrary.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer?> GetCustomerById(int id);

    }
}
