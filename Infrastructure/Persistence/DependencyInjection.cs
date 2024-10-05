using Application.Common.Behaviors.Interfaces;
using EntitySecurity.Contract.Repository;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Common.Interceptors;
using Persistence.Data.Work;
using System.Reflection;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInterceptors(this IServiceCollection services)
        {
            services.AddScoped<ISaveChangesInterceptor, EventInterceptor>();
            services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();

            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ITransactionBehavior, ManagerContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddRepos(this IServiceCollection services, Assembly assembly)
        {
            services.Scan(scan => scan
                .FromAssemblies(assembly)
                .AddClasses((classes) => classes.AssignableToAny(typeof(IRepository)))
                .AsSelfWithInterfaces()
                .WithScopedLifetime());

            return services;
        }

        public static IServiceCollection AddRepoLocks(this IServiceCollection services, Assembly assembly)
        {
            services.Scan(scan => scan
                .FromAssemblies(assembly)
                .AddClasses((classes) => classes.AssignableToAny(typeof(IProtected)))
                .AsSelfWithInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}
