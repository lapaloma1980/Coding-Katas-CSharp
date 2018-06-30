using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    class StringCalculator
    {
        public static int Add(string stringOfSeparatedNumbers, char separator=',')
        {
            int result = 0;

            if (string.IsNullOrEmpty(stringOfSeparatedNumbers))
            {
                return result;
            }

            foreach (string numberString in stringOfSeparatedNumbers.Split(separator))
            {
                if (string.IsNullOrEmpty(numberString) ||
                    string.IsNullOrWhiteSpace(numberString))
                {
                    continue;
                }

                bool isValid = int.TryParse(numberString, out int convertedNumber);

                if (isValid)
                {
                    result += convertedNumber;
                }
            }
           
            return result;
        }
    }
}
