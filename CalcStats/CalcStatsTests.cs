using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CalcStats
{
    [TestFixture]
    public class CalcStatsTests
    {
        [TestCase(-2, "Min")]
        [TestCase(92, "Max")]
        [TestCase(131, "Sum")]
        [TestCase(13.1, "Average")]
        public void TestCalcStats(object expected, string command)
        {
            Assert.AreEqual(expected, CalcStats.GetStats(command, new[] {1, -1, 2, -2, 6, 9, 15, -2, 92, 11}));
        }

        [TestCase(null, new[] {1, -1, 2, -2, 6, 9, 15, -2, 92, 11})]
        [TestCase("", new[] {1, -1, 2, -2, 6, 9, 15, -2, 92, 11})]
        [TestCase("Min", null)]
        [TestCase("Min", new int[] { })]
        public void CalcStats_ThrowsArgumentNullException(string command, int[] values)
        {
            Assert.Throws<ArgumentNullException>(() => CalcStats.GetStats(command, values));
        }

        [TestCase("Bla", new[] {1, -1, 2, -2, 6, 9, 15, -2, 92, 11})]
        public void CalcStats_ThrowsNullReferenceException(string command, int[] values)
        {
            Assert.Throws<NullReferenceException>(() => CalcStats.GetStats(command, values));
        }
    }
}
