using Premium_Demo.Domain;
using System;

namespace Premium_Demo.Dto
{
    public class OccupationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public OccupationRatingType RatingType { get; set; }
    }
}
