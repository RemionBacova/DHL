using DHLWebAPI.Repository;
using DHLWebAPI.Repository.IRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Installer
{
    //This class serves the purpose of removing the code load from Startup.cs
    public class ScopedServices : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            //Part of Repository Pattern for class CustomerAddressRepository
            
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICardsRepository, CardsRepository>();
            
            services.AddScoped<IDiscountRepository, DiscountRepository>();
        }
    }
}
