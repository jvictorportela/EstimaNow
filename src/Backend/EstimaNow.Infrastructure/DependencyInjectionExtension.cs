using EstimaNow.Infrastructure.DataAccess;
using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EstimaNow.Infrastructure;

public static class DependencyInjectionExtension
{
    extension(IServiceCollection services)
    {

        public void AddInfrastructure(IConfiguration configuration)
        {
            //Interfaces dos repositórios também estarão aqui, mas não serão implementadas aqui, apenas injetadas no container de DI

            services.AddDbContext<EstimaNowDbContext>(config =>
            {
                var connectionString = configuration.GetConnectionString("DbConnection")!;

                config.UseMySQL(connectionString);
            });

            services.AddFluentMigratorCore().ConfigureRunner(config =>
            {
                var connectionString = configuration.GetConnectionString("DbConnection")!;

                config
                .AddMySql5()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(Assembly.Load("EstimaNow.Infrastructure"))
                .For.All();
            });
        }
    }
}