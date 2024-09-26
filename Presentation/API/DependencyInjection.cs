using Application.Common.Constants;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistence.Data.Context;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text;

namespace API
{
    public static class DependencyInjection
    {
        public static IHostBuilder AddSerilog(this IHostBuilder webBuilder)
        {
            webBuilder.UseSerilog((ctx, lc) =>
            {
                lc.ReadFrom.Configuration(ctx.Configuration);
            });

            return webBuilder;
        }

        public static IApplicationBuilder UseSerilog(this IApplicationBuilder app)
        {
            app.UseSerilogRequestLogging();

            return app;
        }

        public static IServiceCollection ConfigureApiBehavior(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }

        public static IServiceCollection ConfigureCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            return services;
        }

        public static IServiceCollection AddPreparedControllersWithExplorer(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();

            return services;
        }

        public static IServiceCollection AddIdentityPrepration(this IServiceCollection services)
        {
            services
                .AddIdentityCore<ApplicationUser>(options => { })
                .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(AuthConstants.LoginProvider)
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ManagerContext>()
                .AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection AddSwaggerGenWithBearer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = configuration["Swagger:Title"],
                    Description = configuration["Swagger:Description"]
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });

                options.OrderActionsBy(apiDesc => $"{apiDesc.HttpMethod}_{apiDesc.RelativePath}");
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerGenWithBearer(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.DocExpansion(DocExpansion.None);
            });

            return app;
        }

        public static IServiceCollection AddAuthenticationWithBearer(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
                    };
                });

            return services;
        }
    }
}
