using Application.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Persistence.DapperRepositories;
using System.Data;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDbConnection>(sp => new NpgsqlConnection(configuration.GetConnectionString("Postgresql")));

            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}
