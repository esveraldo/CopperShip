using App.CooperShip.Infra.Intefaces.FailedRepository;
using App.CooperShip.Infra.Interfaces;
using App.CooperShip.Infra.Repositories;
using App.CooperShip.Infra.Repositories.FailedRepository;
using App.CooperShip.Infra.Services;
using App.CooperShip.Infra.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace App.CooperShip.Infra.AutoMapper
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IPessoaFailedRepository, PessoaFailedRepository>();
            services.AddScoped<IVooFailedRepository, VooFailedRepository>();
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IVooService, VooService>();

            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IVooRepository, VooRepository>();
        }
    }
}
