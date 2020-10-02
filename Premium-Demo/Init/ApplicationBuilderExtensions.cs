using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Premium_Demo.DataAccess;

namespace Premium_Demo.Init
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseSeedData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<OccupationDbContext>();
                new OccupationDbContextSeed().SeedAsync(context).Wait();
            }
        }
    }
}
