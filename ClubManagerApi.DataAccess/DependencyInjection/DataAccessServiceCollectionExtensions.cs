
using System;
using System.Data;
using ClubManagerApi.Domain;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;

namespace ClubManagerApi.DataAccess.DependencyInjection
{
    public static class DataAccessServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccessDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDbConnection, SqliteConnection>(s =>
            {
                var connection = new SqliteConnection($"Data Source={Environment.CurrentDirectory}{s.GetService<AppSettings>().DatabasePath}");
                connection.Open();
                return connection;
            });

            services.AddScoped<IMemberRepository, MemberRepository>();

            return services;
        }
    }
}
