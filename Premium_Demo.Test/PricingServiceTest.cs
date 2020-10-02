using Moq;
using Premium_Demo.Domain;
using Premium_Demo.Dto;
using Premium_Demo.Exceptions;
using Premium_Demo.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Premium_Demo.Test
{
    public class PricingServiceTest
    {
        private readonly PricingService _pricingService;
        private readonly Mock<IOccupationRepository> _occupationRepository;

        private static Guid id1 = new Guid("6ad5c44d-623f-4bf1-bf6f-b1c2ee6b7350");       

        public PricingServiceTest()
        {
            _occupationRepository = new Mock<IOccupationRepository>();
            _pricingService = new PricingService(_occupationRepository.Object);
        }

        [Fact]
        public async Task Should_Throw_OccupationNotFound_When_Occupation_Not_Found()
        {
            _occupationRepository.Setup(ar => ar.GetByIdAsync(id1)).Returns(Task.FromResult<Occupation>(null));

            Task handle() => _pricingService.CalculateMonthlyPremiumAsync(
                new PricingDto { OccupationId = id1, Age = 26, CoverAmount = 3000});

            await Assert.ThrowsAsync<OccupationNotFoundException>(handle);
        }

        [Fact]
        public async Task Should_Return_Correct_Value_When_Occupation_Is_Professional()
        {
            _occupationRepository.Setup(ar => ar.GetByIdAsync(id1)).Returns(
                Task.FromResult<Occupation>(new Occupation { Id = id1, RatingType = OccupationRatingType.Professional}));
            decimal expected = (3000m * 26 * 1)/ 12000;

            var result = await _pricingService.CalculateMonthlyPremiumAsync(
                new PricingDto { OccupationId = id1, Age = 26, CoverAmount = 3000 });

            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task Should_Return_Correct_Value_When_Occupation_Is_WhiteCollar()
        {
            _occupationRepository.Setup(ar => ar.GetByIdAsync(id1)).Returns(
                Task.FromResult<Occupation>(new Occupation { Id = id1, RatingType = OccupationRatingType.WhiteCollar }));
            decimal expected = (3000m * 26 * 1.25m) / 12000;

            var result = await _pricingService.CalculateMonthlyPremiumAsync(
                new PricingDto { OccupationId = id1, Age = 26, CoverAmount = 3000 });

            Assert.Equal(expected, result);
        }


        [Fact]
        public async Task Should_Return_Correct_Value_When_Occupation_Is_LightManual()
        {
            _occupationRepository.Setup(ar => ar.GetByIdAsync(id1)).Returns(
                Task.FromResult<Occupation>(new Occupation { Id = id1, RatingType = OccupationRatingType.LightManual }));
            decimal expected = (3000m * 26 * 1.5m) / 12000;

            var result = await _pricingService.CalculateMonthlyPremiumAsync(
                new PricingDto { OccupationId = id1, Age = 26, CoverAmount = 3000 });

            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task Should_Return_Correct_Value_When_Occupation_Is_HeavyManual()
        {
            _occupationRepository.Setup(ar => ar.GetByIdAsync(id1)).Returns(
                Task.FromResult<Occupation>(new Occupation { Id = id1, RatingType = OccupationRatingType.HeavyManual }));
            decimal expected = (3000m * 26 * 1.75m) / 12000;

            var result = await _pricingService.CalculateMonthlyPremiumAsync(
                new PricingDto { OccupationId = id1, Age = 26, CoverAmount = 3000 });

            Assert.Equal(expected, result);
        }
    }
}
