using Microsoft.Extensions.Configuration;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureSample.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureSample.Persistence.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("myconnection");
            services.AddDbContext<TraineeDbContext>(options=>options.UseSqlServer(connectionString,builder=>builder.MigrationsAssembly(typeof(TraineeDbContext).Assembly.FullName)));
        }
    }
}
