using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CalcStats
{
    class CalcStats
    {
        public static object GetStats(string command, int[] sequence)
        {
            if (string.IsNullOrEmpty(command) || string.IsNullOrWhiteSpace(command)) throw new ArgumentNullException(nameof(command));
            if (sequence == null || sequence.Count() == 0) throw new ArgumentNullException(nameof(sequence));

            object result;
            try
            {
                MethodInfo mi = typeof(Enumerable).GetMethod(command, new[] { typeof(IEnumerable<int>) });
                result = mi.Invoke(sequence, new[] { sequence });
            }
            catch (NullReferenceException e)
            {
                throw e;
            }

            return result;
        }
    }
}
