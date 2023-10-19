using CleanArchitectureSample.Domain.Common.Interfaces;
using CleanArchitectureSample.Domain.Common;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureSample.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services
                .AddTransient<IMediator, Mediator>()
                 .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>();
        }
    }
}
