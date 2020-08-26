using AutoMapper;
using Livraria.Application;
using Livraria.Application.AutoMapper;
using Livraria.Application.Interfaces;
using Livraria.Domain.Interfaces;
using Livraria.Infra.Data;
using Livraria.Infra.Data.Repository;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Livraria.Infra.CrossCutting.Ioc
{
    public class NativeDependencyInjection
    {
        public void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataBaseContext>(options => {
                options.UseSqlServer(
                    configuration["ConnectionStrings:Database"]);
            }, ServiceLifetime.Transient);

            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddHttpContextAccessor();

            //Applications
            services.AddScoped<ILivrariaApplication, LivrariaApplication>();

            //Repositories
            services.AddScoped<ILivrariaRepository, LivrariaRepository>();

            //Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
