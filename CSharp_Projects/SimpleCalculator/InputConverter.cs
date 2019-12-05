using System;

namespace SimpleCalculator
{
    public class InputConverter
    {
        public double ConvertInputToNumeric(string input)
        {
            double formattedNumber;
            if (!double.TryParse(input, out formattedNumber))
            {
                throw new ArgumentException("Input is not numeric");
            }
            return formattedNumber;
        }
    }
}