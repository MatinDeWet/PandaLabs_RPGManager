using API;
using API.Middleware;
using Application;
using EntitySecurity.Logic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Persistence;
using Persistence.Data.Context;
using System.Reflection;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Host.AddSerilog();
        builder.Services.AddCustomExceptionHandler();

        builder.Services.AddPreparedControllersWithExplorer();

        builder.Services.ConfigureApiBehavior();
        builder.Services.ConfigureCorsPolicy();

        builder.Services.AddSwaggerGenWithBearer(builder.Configuration);

        builder.Services
            .AddIdentityPrepration()
            .AddAuthenticationWithBearer(builder.Configuration);

        builder.Services
            .AddMediatRBehaviorWithMapper(true, typeof(Application.DependencyInjection).Assembly);

        builder.Services.AddDbContext<ManagerContext>((sp, options) =>
        {
            options.UseNpgsql(
                builder.Configuration.GetConnectionString("RpgConnection"),
                opt => opt.MigrationsAssembly(typeof(ManagerContext).GetTypeInfo().Assembly.GetName().Name)
            );

            if (builder.Environment.IsDevelopment())
            {
                options.EnableSensitiveDataLogging();
            }

            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
        });

        builder.Services
            .AddInterceptors()
            .AddEntitySecurity()
            .AddRepos(typeof(Persistence.DependencyInjection).Assembly)
            .AddRepoLocks(typeof(Persistence.DependencyInjection).Assembly)
            .AddInfrastructure();

        var app = builder.Build();

        app.UseSerilog();
        app.UseCustomExceptionHandler();

        app.UseSwaggerGenWithBearer(builder.Configuration);

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseMiddleware<UserIdentifierMiddleware>();

        app.MapControllers()
            .RequireAuthorization();

        ApplyDbMigrations(app);

        app.Run();
    }

    internal static void ApplyDbMigrations(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope();

        if (serviceScope.ServiceProvider.GetRequiredService<ManagerContext>().Database.GetPendingMigrations().Count() > 0)
            serviceScope.ServiceProvider.GetRequiredService<ManagerContext>().Database.Migrate();
    }
}