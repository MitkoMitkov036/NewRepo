using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.DependencyInjection;
using WatchService.DL.Interfaces;
using WatchService.DL.Repositories;

namespace WatchService.DL.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services)
        {
            services.AddScoped<IWatchRepository, MongoWatchRepository>();
            services.AddScoped<ICustomerRepository, MongoCustomerRepository>();
            return services;
        }
    }
}
