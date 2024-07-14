using AspNetCoreRateLimit;
namespace RateLimitingWebApp
{
    public static class RateLimitConfig
    {
        public static void AddRateLimitServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<IpRateLimitOptions>(configuration.GetSection("IpRateLimiting"));

            services.AddInMemoryRateLimiting();

            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        }
    }
}
