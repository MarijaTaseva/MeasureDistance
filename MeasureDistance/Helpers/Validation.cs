using System;
using System.Linq;

namespace MeasureDistance.Helpers
{
    public static class Validation
    {
        public static bool ValidateIataCode(string iataCode)
        {
            return (!String.IsNullOrEmpty(iataCode) && iataCode.Length == 3 && iataCode.All(Char.IsLetter));
        }
    }
}
