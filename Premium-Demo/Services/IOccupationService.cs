using Premium_Demo.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Premium_Demo.Services
{
    public interface IOccupationService
    {
        Task<IEnumerable<OccupationDto>> GetOccupationsAsync();
        Task<OccupationDto> GetOccupationByIdAsync(Guid Id);
    }
}
