using CleanArchitectureSample.Application.Interfaces;
using CleanArchitectureSample.Application.Interfaces.Repositories;
using CleanArchitectureSample.Persistence.Contexts;
using CleanArchitectureSample.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureSample.Persistence.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddRepositories();

        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("myconnection");
            services.AddDbContext<TraineeDbContext>(options=>options.UseSqlServer(connectionString,builder=>builder.MigrationsAssembly(typeof(TraineeDbContext).Assembly.FullName)));
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
        }
    }
}
