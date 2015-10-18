using System.Collections.Generic;
using System.Linq;

namespace Homunculus.Core.Extensions
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Implement a dot product method using LINQ.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static float DotProduct(this IEnumerable<float> v1, IEnumerable<float> v2)
        {
            return v1.Zip(v2, (a, b) => a*b).Sum();
        }
    }
}