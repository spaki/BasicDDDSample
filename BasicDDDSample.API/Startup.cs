using BasicDDDSample.API.Configuration;
using BasicDDDSample.Domain.Infra.Settings;
using BasicDDDSample.Domain.Services.Common;
using BasicDDDSample.Repository.Common;
using BasicDDDSample.Repository.EF.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BasicDDDSample.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => AppSettings = configuration.Get<AppSettings>();

        public AppSettings AppSettings { get; }

        public void ConfigureServices(IServiceCollection services) => services
            .AddSwagger()
            .AddSqlServerMainDb(AppSettings)
            .AddSingleton(AppSettings)
            .AddScopedByBaseType(typeof(ServiceBase))
            .AddScopedByBaseType(typeof(RepositoryBase))
            .AddControllers();

        public void Configure(IApplicationBuilder app, MainDbContext mainDbContext) => app
                .UseCustomCors()
                .UseDeveloperExceptionPage()
                .UseHttpsRedirection()
                .UseSwagger()
                .UseSawaggerWithDocs()
                .UseDatabaseMigration(mainDbContext)
                .UseRouting()
                .UseAuthorization()
                .UseControllersEndpoints();
    }
}
