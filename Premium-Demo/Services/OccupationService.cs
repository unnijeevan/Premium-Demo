using Premium_Demo.Domain;
using Premium_Demo.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Premium_Demo.Services
{
    public class OccupationService : IOccupationService
    {
        private readonly IOccupationRepository _occupationRepository;
        public OccupationService(IOccupationRepository occupationRepository)
        {
            _occupationRepository = occupationRepository;
        }

        public async Task<OccupationDto> GetOccupationByIdAsync(Guid id)
        {
            var occupation = await _occupationRepository.GetByIdAsync(id);
            return occupation != null ? new OccupationDto
            {
                Id = occupation.Id,
                Name = occupation.Name,
                RatingType = occupation.RatingType
            } : null;
        }

        public async Task<IEnumerable<OccupationDto>> GetOccupationsAsync()
        {
            var occupations = await _occupationRepository.GetAllAsync();
            return occupations.Select(oc => new OccupationDto
            {
                Id = oc.Id,
                Name = oc.Name,
                RatingType = oc.RatingType
            });
        }
    }
}
