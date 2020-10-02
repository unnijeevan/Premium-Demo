using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Premium_Demo.Exceptions
{
    public class OccupationNotFoundException : Exception
    {
        public OccupationNotFoundException(Exception ex) :
           base($"Occupation not found", ex)
        {
        }
    }
}
