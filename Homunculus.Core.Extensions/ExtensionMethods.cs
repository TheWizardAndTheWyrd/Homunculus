using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Homunculus.Core.Extensions
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Implements a dot product method using LINQ.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static float DotProduct(this IEnumerable<float> v1, IEnumerable<float> v2)
        {
            return v1.Zip(v2, (a, b) => a*b).Sum();
        }

        [SuppressMessage("ReSharper", "MethodOverloadWithOptionalParameter")]
        public static float DotProduct(this IEnumerable<float> v1, IEnumerable<float> v2, int acc = 0)
        {
            return v1.Zip(v2, (a, b) => (a * b) + acc).Sum() + acc;
        }

        public static float DotProduct(this IEnumerable<float> v1, IEnumerable<float> v2, float acc)
        {
            return v1.Zip(v2, (a, b) => (a * b) + acc).Sum() + acc;
        }

        /// <summary>
        /// No crazed values when generating a random float.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float NextFloat(this Random value)
        {
            double mantissa = (value.NextDouble() * 2.0) - 1.0;
            double exponent = Math.Pow(2.0, value.Next(-126, 128));
            return (float)(mantissa * exponent);
        }

        public static List<T> ToList<T>(this Tuple<T, T, T> value)
        {
            return new List<T> {value.Item1, value.Item2, value.Item3};
        }
    }
}