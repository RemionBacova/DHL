
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DHLWebAPI.Repository;
using DHLWebAPI.Repository.IRepository;

namespace DHLWebAPI.Installer
{
    public class ScopedServices : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICardsRepository, CardsRepository>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
        }
    }
}
