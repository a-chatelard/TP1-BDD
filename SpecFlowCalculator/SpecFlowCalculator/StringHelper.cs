using System;

namespace SpecFlowCalculator
{
    public static class StringHelper
    {
        public static decimal ToDecimal(this string floatToParse)
        {
            if (decimal.TryParse(floatToParse, out var decimalNumber))
            {
                return decimalNumber;
            }
            throw new InvalidOperationException("Invalid operation.");
        }
    }
}
