using App.CooperShip.Domain.Entities;
using App.CooperShip.Infra.DTOs;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace App.CooperShip.Infra.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Pessoa, PessoaDTO>().ReverseMap();
                cfg.CreateMap<Voo, VooDTO>().ReverseMap();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());
        }
    }
}
