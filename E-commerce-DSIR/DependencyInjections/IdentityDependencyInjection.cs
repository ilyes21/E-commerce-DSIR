using E_commerce_DSIR.Data;
using Microsoft.AspNetCore.Identity;

namespace E_commerce_DSIR.DependencyInjections
{
    public static class IdentityDependencyInjection
    {
        public static IServiceCollection AddIdentityDependencyInjection(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(opt =>
            {
                // Password settings
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireUppercase = true;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 6;
                opt.User.RequireUniqueEmail = true;
                // Lockout settings
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                opt.Lockout.MaxFailedAccessAttempts = 5;
                opt.Lockout.AllowedForNewUsers = true;
                // user settings
                opt.User.RequireUniqueEmail = true;
                // SignIn settings
                opt.SignIn.RequireConfirmedEmail = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            return services;
        }
    }
}
