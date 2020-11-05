
using ClubManagerApi.DataAccess.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace ClubManagerApi.Business.DependencyInjection
{
    public static class BusinessServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessDependencies(this IServiceCollection services)
        {
            services.AddDataAccessDependencies();

            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
