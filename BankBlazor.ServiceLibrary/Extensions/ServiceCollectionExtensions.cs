using BankBlazor.ServiceLibrary.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBlazor.ServiceLibrary.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBankBlazorContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BankBlazorContext>(options =>
                options.UseSqlServer(connectionString));
            return services;
        }
    }
}
