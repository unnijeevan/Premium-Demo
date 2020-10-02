using Moq;
using Premium_Demo.Domain;
using Premium_Demo.Dto;
using Premium_Demo.Exceptions;
using Premium_Demo.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Premium_Demo.Test
{
    public class PricingServiceTest
    {
        private readonly PricingService _pricingService;
        private readonly Mock<IOccupationRepository> _occupationRepository;

        private static Guid Id1 = new Guid("6ad5c44d-623f-4bf1-bf6f-b1c2ee6b7350");
        private static Guid Id2 = new Guid("50b0670e-7cf7-4acf-a697-7845d5cea43a");
        private static Guid Id3 = new Guid("fb6f539f-2b2b-409a-a49e-672c35733d90");
        private static Guid Id4 = new Guid("4b509755-3ead-4d0f-a011-a6a02e64e3cd");

        public PricingServiceTest()
        {
            _occupationRepository = new Mock<IOccupationRepository>();
            _pricingService = new PricingService(_occupationRepository.Object);
        }

        [Fact]
        public async Task Should_Throw_OccupationNotFound_When_Occupation_Not_Found()
        {
            _occupationRepository.Setup(ar => ar.GetByIdAsync(Id1)).Returns(Task.FromResult<Occupation>(null));

            Task handle() => _pricingService.CalculateMonthlyPremiumAsync(
                new PricingDto { OccupationId = Id1, Age = 26, CoverAmount = 3000});

            await Assert.ThrowsAsync<OccupationNotFoundException>(handle);
        }
    }
}
