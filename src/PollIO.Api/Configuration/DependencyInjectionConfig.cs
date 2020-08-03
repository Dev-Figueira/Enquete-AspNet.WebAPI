using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PollIO.Business.Interfaces;
using PollIO.Business.Notificacoes;
using PollIO.Business.Services;
using PollIO.Data.Context;
using PollIO.Data.Repository;

namespace PollIO.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<PollDbContext>();
            services.AddScoped<IPollRepository, PollRepository>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IPollService, PollService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}
