using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Premium_Demo.Domain
{
    public interface IOccupationRepository
    {
        Task<IEnumerable<Occupation>> GetAllAsync();
        Task<Occupation> GetByIdAsync(Guid id);
    }
}
