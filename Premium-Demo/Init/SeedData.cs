using Premium_Demo.Domain;
using System;
using System.Collections.Generic;

namespace Premium_Demo.Init
{
    internal static class SeedData
    {
        private static Guid Id1 = new Guid("6ad5c44d-623f-4bf1-bf6f-b1c2ee6b7350");
        private static Guid Id2 = new Guid("50b0670e-7cf7-4acf-a697-7845d5cea43a");
        private static Guid Id3 = new Guid("fb6f539f-2b2b-409a-a49e-672c35733d90");
        private static Guid Id4 = new Guid("4b509755-3ead-4d0f-a011-a6a02e64e3cd");
        private static Guid Id5 = new Guid("b495e2d4-b9d6-4474-993f-f0270b5eb1c9");
        private static Guid Id6 = new Guid("dc4b6fdc-19de-449f-92ce-d2c50b0da904");

        internal static IEnumerable<Occupation> Occupations()
        {
            return new List<Occupation>()
            {
                new Occupation { Id = Id1, Name = "Cleaner", RatingType = OccupationRatingType.LightManual },
                new Occupation { Id = Id2, Name = "Doctor", RatingType = OccupationRatingType.Professional },
                new Occupation { Id = Id3, Name = "Author", RatingType = OccupationRatingType.WhiteCollar },
                new Occupation { Id = Id4, Name = "Farmer", RatingType = OccupationRatingType.HeavyManual },
                new Occupation { Id = Id5, Name = "Mechanic", RatingType = OccupationRatingType.HeavyManual },
                new Occupation { Id = Id6, Name = "Florist", RatingType = OccupationRatingType.LightManual }
            };
        }
    }
}
