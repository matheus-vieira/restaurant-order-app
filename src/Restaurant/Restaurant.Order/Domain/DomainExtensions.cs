using Microsoft.Extensions.DependencyInjection;
using System;

namespace Restaurant.Order.Domain
{
    public static class DomainExtensions
    {
        public static IServiceCollection UseDomain(this IServiceCollection services)
        {
            services.AddTransient<MorningDishes>();
            services.AddTransient<NightDishes>();

            services.AddTransient<Func<string, IDishes>>(serviceProvider => name =>
            {
                return name switch
                {
                    MorningDishes.Name => serviceProvider.GetService<MorningDishes>(),
                    NightDishes.Name => serviceProvider.GetService<NightDishes>(),
                    _ => null,
                };
            });

            return services;
        }
    }
}
