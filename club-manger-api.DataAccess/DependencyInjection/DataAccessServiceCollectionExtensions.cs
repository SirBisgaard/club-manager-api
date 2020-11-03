
using Microsoft.Extensions.DependencyInjection;

namespace club_manger_api.DataAccess.DependencyInjection
{
    public static class DataAccessServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccessDependencies(this IServiceCollection services)
        {
            services.AddScoped<IMemberRepository, MemberRepository>();

            return services;
        }
    }
}
