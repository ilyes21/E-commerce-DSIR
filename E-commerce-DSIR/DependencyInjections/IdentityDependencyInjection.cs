using E_commerce_DSIR.Data;
using Microsoft.AspNetCore.Identity;

namespace E_commerce_DSIR.DependencyInjections
{
    public static class IdentityDependencyInjection
    {
        public static IServiceCollection AddIdentityDependencyInjection(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            return services;
        }
    }
}
