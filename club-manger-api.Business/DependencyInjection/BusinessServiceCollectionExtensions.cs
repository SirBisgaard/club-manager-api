
using club_manger_api.DataAccess.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace club_manger_api.Business.DependencyInjection
{
    public static class BusinessServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessDependencies(this IServiceCollection services)
        {
            services.AddDataAccessDependencies();

            services.AddScoped<IMemberService, MemberService>();

            return services;
        }
    }
}
