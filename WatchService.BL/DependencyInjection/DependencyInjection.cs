using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.DependencyInjection;
using WatchService.BL.Interfaces;
using WatchService.BL.Services;

namespace WatchService.BL.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            services.AddScoped<IWatchCrudService, WatchCrudService>();
            services.AddScoped<ISellWatchService, SellWatchService>();
            return services;
        }
    }
}
