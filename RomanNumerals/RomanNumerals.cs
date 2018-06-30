using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;

namespace RomanNumerals
{
    class RomanNumerals
    {

        private static string validationPattern = @"^(?=[MDCLXVI])M{0,3}(C[MD]|D|C{0,3})(X[CL]|L|X{0,3})(I[XV]|V|I{0,3})$";
        private static Regex isValidRoman = new Regex(validationPattern);

        private static IDictionary<char, int> toIntegerDictionary = new Dictionary<char, int>
        {
            {'M', 1000},
            {'D', 500},
            {'C', 100},
            {'L', 50},
            {'X', 10},
            {'V', 5},
            {'I', 1},
        };
        private static IDictionary<string, int> toRomanDictionary = new Dictionary<string, int>
        {
            {"M", 1000},
            {"CM", 900},
            {"D", 500},
            {"CD", 400},
            {"C", 100},
            {"XC", 90},
            {"L", 50},
            {"XL", 40},
            {"X", 10},
            {"IX", 9},
            {"V", 5},
            {"IV", 4},
            {"I", 1},
        };
        public static int ToInteger(string romanNumber)
        {
            romanNumber = romanNumber.ToUpper();
            int integerResult = 0;

            if(string.IsNullOrEmpty(romanNumber) || string.IsNullOrWhiteSpace(romanNumber))
                throw new ArgumentNullException("Empty or null argument not allowed!");

            if (!IsValidRomanNumber(romanNumber))
                throw new FormatException("Invalid roman number format!");

            for (int i = 0; i < romanNumber.Length; i++)
            {
                int numberValue = toIntegerDictionary[romanNumber[i]];
                if (i < romanNumber.Length - 1 && 
                    numberValue < toIntegerDictionary[romanNumber[i+1]])
                {
                    integerResult -= numberValue;
                }
                else
                {
                    integerResult += numberValue;
                }
            }
            return integerResult;
        }

        public static string ToRoman(int number)
        {
            string romanResult = "";
            IList<string> romanNumberList = new List<string>(toRomanDictionary.Keys);

            if (number < 1 || number > 3999)
            {
                throw  new ArgumentOutOfRangeException("Argument value need to be from 1 - 3999!");
            }
            
            foreach (string romanNumber in romanNumberList)
            {
                int romanNumberValue = toRomanDictionary[romanNumber];

                while (romanNumberValue <= number)
                {
                    romanResult += romanNumber;
                    number -= romanNumberValue;
                }
            }

            return romanResult;
        }

        private static bool IsValidRomanNumber(string romanNumber)
        {
            return isValidRoman.IsMatch(romanNumber);
        }
    }
}
