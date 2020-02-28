using BasicDDDSample.Domain.Infra.Settings;
using BasicDDDSample.Repository.EF.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;
using System.Reflection;

namespace BasicDDDSample.API.Configuration
{
    public static class ConfigurationHelper
    {
        public static IServiceCollection AddScopedByBaseType(this IServiceCollection services, Type baseType)
        {
            Assembly
                .GetAssembly(baseType)
                .GetTypes()
                .Where(type =>
                    type.BaseType != null
                    && (
                        (type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == baseType)) // -> Generics, ex: CrudRepository<>
                        || (baseType.IsAssignableFrom(type) && !type.IsAbstract) // -> Non generics, ex: Repository
                    )
                .ToList()
                .ForEach(type => services.AddScoped(type.GetInterface($"I{type.Name}"), type));

            return services;
        }


        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Basic DDD Sample API", Version = "v1" });
            });

            return services;
        }

        public static IServiceCollection AddSqlServerMainDb(this IServiceCollection services, AppSettings settings)
        {
            services.AddDbContext<MainDbContext>(options =>
                options
                    .UseLazyLoadingProxies()
                    .UseSqlServer(settings.MainDbConnectionString)
            );

            return services;
        }


        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app, MainDbContext mainDbContext)
        {
            mainDbContext.Database.Migrate();
            return app;
        }

        public static IApplicationBuilder UseCustomCors(this IApplicationBuilder app)
        {
            app.UseCors(builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowAnyOrigin();
            });

            return app;
        }

        public static IApplicationBuilder UseSawaggerWithDocs(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                var swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Loja SAS");
            });

            return app;
        }

        public static IApplicationBuilder UseControllersEndpoints(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}
