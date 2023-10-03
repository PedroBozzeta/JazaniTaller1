using JazaniT1.Application.Admins.Services;
using JazaniT1.Application.Admins.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace JazaniT1.Application.Cores.Contexts
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<ILevelEducationService, LevelEducationService>();
            services.AddTransient<IMeasureUnitService, MeasureUnitService>();

            return services;
        }
    }
}
