using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProviderService.DataProvider;
using ProviderService.IDataProvider;
using SessionProvider;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProviderService
{
   public static class ServiceConfiguration
    {
        public static void AddProviderService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddTransient<IUserMasterProvider, UserMasterProvider>();
            services.AddSessionservice(configuration);
        }
    }
}
