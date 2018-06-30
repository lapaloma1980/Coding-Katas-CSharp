using System;
using NUnit.Framework;

namespace StringCalculator
{
    [TestFixture]
    class StringCalculatorTest
    {
        [TestCase(6, "1,2,3")]
        [TestCase(0, "")]
        [TestCase(1, "1, ")]
        [TestCase(2, "abc,2")]
        [TestCase(55, "1.2.3.4.5.6.7.8.9.10", '.')]
        [TestCase(6, "1#2#3", '#')]
        public void TestAdd(int expected, string stringOfSeperatedNumbers, char separator = ',')
        {
            Assert.AreEqual(expected, StringCalculator.Add(stringOfSeperatedNumbers, separator));
        }
    }
}
