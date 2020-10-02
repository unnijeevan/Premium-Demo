using Premium_Demo.Domain;
using Premium_Demo.Dto;
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

        public async Task<decimal> CalculateMonthlyPremiumAsync(PricingDto pricingParamDto)
        {
            throw new NotImplementedException();
        }
    }
}
