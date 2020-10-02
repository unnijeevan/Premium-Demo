using Premium_Demo.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Premium_Demo.Services
{
    public interface IPricingService
    {
        Task<decimal> CalculateMonthlyPremiumAsync(PricingDto pricingDto);
    }
}
