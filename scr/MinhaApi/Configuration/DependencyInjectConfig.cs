using Microsoft.Extensions.DependencyInjection;
using MinhaApi.Business.Interfaces;
using MinhaApi.Business.Notifications;
using MinhaApi.Business.Services;
using MinhaApi.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaApi.Api.Configuration
{
    public static class DependencyInjectConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();

            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped<IEnderecoService, EnderecoService>();

            services.AddScoped<IClienteService, ClienteService>();

            services.AddScoped<INotificador, Notificador>();
            return services;
        }
    }

    

}
