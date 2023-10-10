using JazaniT1.Domain.Admins.Repositories;
using JazaniT1.Domain.Cores.Paginations;
using JazaniT1.Infrastructure.Admins.Persistences;
using JazaniT1.Infrastructure.Cores.Paginations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace JazaniT1.Infrastructure.Cores.Contexts
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection addInfrastructureServices(this IServiceCollection services
            , IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });

            services.AddTransient(typeof(IPaginator<>), typeof(Paginator<>));
            return services;
        }
    }
}
