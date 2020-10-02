using Microsoft.EntityFrameworkCore;
using Premium_Demo.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Premium_Demo.DataAccess
{
    public class OccupationRepository : IOccupationRepository
    {
        private readonly OccupationDbContext _occupationDbContext;

        public OccupationRepository(OccupationDbContext  occupationDbContext)
        {
            _occupationDbContext = occupationDbContext;
        }

        public async Task<IEnumerable<Occupation>> GetAllAsync()
        {
            return await _occupationDbContext.Occupations.ToListAsync();
        }

        public async Task<Occupation> GetByIdAsync(Guid id)
        {
            return await _occupationDbContext.Occupations.SingleOrDefaultAsync(o => o.Id == id);
        }
    }
}
