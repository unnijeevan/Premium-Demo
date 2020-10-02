using Premium_Demo.DataAccess;
using System.Linq;
using System.Threading.Tasks;

namespace Premium_Demo.Init
{
    public class OccupationDbContextSeed
    {
        public async Task SeedAsync(OccupationDbContext occupationDbContext)
        {
            await occupationDbContext.Database.EnsureCreatedAsync();
            if (occupationDbContext.Occupations.Any())
                return;
            await occupationDbContext.Occupations.AddRangeAsync(SeedData.Occupations());
            await occupationDbContext.SaveChangesAsync();
        }
    }
}
