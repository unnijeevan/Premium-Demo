using Moq;
using Premium_Demo.Domain;
using Premium_Demo.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Premium_Demo.Test
{
    public class OccupationServcieTest
    {
        private readonly Mock<IOccupationRepository> _occupationRepository;
        private readonly OccupationService _occupationService;

        private Guid testItemId1 = new Guid("d1465ab8-834a-4d4a-9b29-8f5fbdac4e0c");

        public OccupationServcieTest()
        {
            _occupationRepository = new Mock<IOccupationRepository>();
            _occupationService = new OccupationService(_occupationRepository.Object);
        }


        [Fact]
        public async Task Should_Return_Empty_List_If_No_Occupations_In_Repository()
        {
            _occupationRepository.Setup(or => or.GetAllAsync()).Returns(Task.FromResult<IEnumerable<Occupation>>(new List<Occupation>()));

            var result = await _occupationService.GetOccupationsAsync();

            Assert.Empty(result);
        }

        [Fact]
        public async Task Should_Return_Occupation_By_Id()
        {
            _occupationRepository.Setup(or => or.GetByIdAsync(testItemId1)).Returns(Task.FromResult<Occupation>(
                new Occupation { Id = testItemId1 }));

            var result = await _occupationService.GetOccupationByIdAsync(testItemId1);

            Assert.Equal(testItemId1, result.Id);
        }


        [Fact]
        public async Task Should_Return_Null_If_Occupation_NotPresent()
        {
            _occupationRepository.Setup(or => or.GetByIdAsync(testItemId1)).Returns(Task.FromResult<Occupation>(null));

            var result = await _occupationService.GetOccupationByIdAsync(testItemId1);

            Assert.Null(result);
        }
    }
}
