using System;

namespace Premium_Demo.Domain
{
    public class Occupation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public OccupationRatingType RatingType { get; set; }
    }
}
