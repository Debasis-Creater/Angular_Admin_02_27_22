using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SessionProvider.IProvider;
using SessionProvider.Provider;
using System;
using System.Collections.Generic;
using System.Text;

namespace SessionProvider
{
   public static class ServiceConfiguration
    {
        public static void AddSessionservice(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddTransient<ISessionProviderService, SessionProviderService>();
        }
    }
}
