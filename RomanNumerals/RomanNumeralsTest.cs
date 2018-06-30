using System;
using NUnit.Framework;

namespace RomanNumerals
{
    [TestFixture]
    class RomanNumeralsTest
    {
        [TestCase(1, "I")]
        [TestCase(5, "V")]
        [TestCase(10, "X")]
        [TestCase(50, "L")]
        [TestCase(100, "C")]
        [TestCase(500, "D")]
        [TestCase(1000, "M")]
        [TestCase(2, "II")]
        [TestCase(4, "IV")]
        [TestCase(9, "IX")]
        [TestCase(3999, "MMMCMXCIX")]
        public void TestToInteger(int expected, string romanNumber)
        {
            Assert.AreEqual(expected, RomanNumerals.ToInteger(romanNumber));
        }

        [TestCase("I", 1)]
        [TestCase("IV", 4)]
        [TestCase("V", 5)]
        [TestCase("IX", 9)]
        [TestCase("X", 10)]
        [TestCase("XL", 40)]
        [TestCase("L", 50)]
        [TestCase("XC", 90)]
        [TestCase("C", 100)]
        [TestCase("CD", 400)]
        [TestCase("D", 500)]
        [TestCase("CM", 900)]
        [TestCase("M", 1000)]
        [TestCase("II", 2)]
        [TestCase("IV", 4)]
        [TestCase("IX", 9)]
        [TestCase("CDXCIX", 499)]
        [TestCase("MMCDXVIII", 2418)]
        [TestCase("MMMCMXCIX", 3999)]
        public void TestToRoman(string expected, int number)
        {
            Assert.AreEqual(expected, RomanNumerals.ToRoman(number));
        }

        [TestCase("MMMCMXCIXXXX")]
        [TestCase("MMMM")]
        [TestCase("MMMCMXCIYXX")]
        public void ToInteger_ThrowsFormatException(string romanNumber)
        {
            Assert.Throws<FormatException>(()=>RomanNumerals.ToInteger(romanNumber), "Invalid roman number format!");
        }

        [TestCase("")]
        [TestCase(" ")]
        public void ToInteger_ThrowsArgumentNullException(string romanNumber)
        {
            Assert.Throws<ArgumentNullException>(() => RomanNumerals.ToInteger(romanNumber), "Empty or null argument not allowed!");
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(4000)]
        public void ToRoman_ThrowsArgumentOutOfRangeException(int number)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => RomanNumerals.ToRoman(number), "Argument value need to be from 1 - 3999!");
        }
    }
}
