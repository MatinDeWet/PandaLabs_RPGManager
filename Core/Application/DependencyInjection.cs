using Application.Common.Behaviors;
using Application.Common.Exceptions.Handler;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMediatRBehaviorWithMapper(this IServiceCollection services, bool EnableTransactionRollback, Assembly assembly)
        {
            services.AddValidatorsFromAssembly(assembly);

            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(assembly);
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
                config.AddOpenBehavior(typeof(TrackingBehavior<,>));
                config.AddOpenBehavior(typeof(LoggingBehavior<,>));
            });

            return services;
        }

        public static IServiceCollection AddCustomExceptionHandler(this IServiceCollection services)
        {
            services.AddExceptionHandler<CustomExceptionHandler>();

            return services;
        }

        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(options => { });

            return app;
        }
    }
}
