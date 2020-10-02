using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Premium_Demo.Models
{
    public class PricingRequest
    {
        public int Age { get; set; }
        public decimal CoverAmount { get; set; }
        public Guid OccupationId { get; set; }
    }
}
