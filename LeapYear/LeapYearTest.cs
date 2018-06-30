
using System;
using NUnit.Framework;

namespace LeapYear
{
    [TestFixture]
    class LeapYearTest
    {
        [TestCase(true, 2000)]
        [TestCase(false, 2013)]
        [TestCase(false, 2001)]
        [TestCase(true, 1996)]
        [TestCase(true, 1992)]
        [TestCase(false, 1)]
        public void TestIsLeapYear(bool expected, int year)
        {
            Assert.AreEqual(expected, IsLeapYear(year));
        }


        [TestCase(0)]
        [TestCase(-1)]
        public void IsLeapYear_ThrowsArgumentOutOfRangeException(int year)
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => IsLeapYear(year), 
                "The year argument need to be 1 or more!"
                );
        }

        public bool IsLeapYear(int year)
        {
            if (year < 1)
            {
                throw new ArgumentOutOfRangeException("The year argument need to be 1 or more!");
            }

            if (year % 400 == 0)
            {
                return true;
            }
           
            return (year % 4 == 0 && year % 100 != 0);
        }
    }
}
