using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Premium_Demo.Domain;

namespace Premium_Demo.DataAccess
{
    public static class DbConfig
    {
        public static IServiceCollection AddDbConfiguration(this IServiceCollection services)
        {
            services.AddDbContext<OccupationDbContext>(options =>
            {
                options.UseInMemoryDatabase("BiddingService");
            });
            services.AddScoped<IOccupationRepository, OccupationRepository>();
            return services;
        }
    }
}
