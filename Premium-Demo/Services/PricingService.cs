using Premium_Demo.Domain;
using Premium_Demo.Dto;
using Premium_Demo.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Premium_Demo.Services
{
    public class PricingService : IPricingService
    {
        private readonly IOccupationRepository _occupationRepository;

        public PricingService(IOccupationRepository occupationRepository)
        {
            _occupationRepository = occupationRepository;
        }

        public async Task<decimal> CalculateMonthlyPremiumAsync(PricingDto pricingDto)
        {
            //the whole occupation list could be cached for better performances
            var occupation = await _occupationRepository.GetByIdAsync(pricingDto.OccupationId);
            if (occupation == null)
                throw new OccupationNotFoundException(new Exception($"Occupation {pricingDto.OccupationId} not found"));
            else
            {
                var ratingFactor = RatingFactor(occupation.RatingType);
                return CalculateMonthlyPremium(pricingDto.CoverAmount, pricingDto.Age, ratingFactor);
            }
        }

        private decimal CalculateMonthlyPremium(decimal coverAmount, int age, double ratingFactor)
        {
            return (coverAmount * age * (decimal)ratingFactor) / 12000;
        }

        private double RatingFactor(OccupationRatingType ratingType) =>
        ratingType switch
        {
            OccupationRatingType.Professional => 1.0,
            OccupationRatingType.WhiteCollar => 1.25,
            OccupationRatingType.LightManual => 1.5,
            OccupationRatingType.HeavyManual => 1.75,
            _ => throw new NotImplementedException()
        };
    }
}
