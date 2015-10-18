using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homunculus.Core.Extensions;

namespace Homunculus.Core.Tests.Extensions
{
    [TestClass]
    public class ExtensionMethods
    {
        /// <summary>
        /// TODO: Determin why assertion fails without casting to string; probably because of the floating point precision.
        /// </summary>
        [TestMethod]
        public void DotProductTest()
        {
            // Arrange
            float v1 = 0.2342523523523452345F;
            float v2 = 0.2342523523523452345F;

            List<float> leftValues = new List<float>() {v1};
            List<float> rightValues = new List<float>() {v2};

            float result;

            // Act
            result = leftValues.DotProduct(rightValues);

            // Assert
            Assert.AreNotEqual(0, result);
            Assert.AreEqual(0.05487416F.ToString(), result.ToString());
            Console.WriteLine("String Result of DotProduct invocation: {0}", result);
        }

        [TestMethod]
        public void DotProductWithAccumulatorTest()
        {
            // Arrange
            float v1 = 0.2342523523523452345F;
            float v2 = 0.2342523523523452345F;
            int accumulator = 1;

            List<float> leftValues = new List<float>() { v1 };
            List<float> rightValues = new List<float>() { v2 };

            float result;

            // Act
            result = leftValues.DotProduct(rightValues, accumulator);

            // Assert
            Assert.AreNotEqual(0, result);
            //Assert.AreEqual(0.05487416F.ToString(), result.ToString());
            Console.WriteLine("String Result of DotProduct invocation: {0}", result);
        }

        [TestMethod]
        public void MultipleValueDotProductTest()
        {
            // Arrange
            float v1 = 0.2342523523523452345F;
            float v2 = 0.2342523523523452345F;

            float v3 = 0.8298239857283975982F;
            float v4 = 0.8298239857283975982F;

            List<float> leftValues = new List<float>() {v1, v3};
            List<float> rightValues = new List<float>() {v2, v4};

            float result;

            // Act
            result = leftValues.DotProduct(rightValues);

            // Assert
            Assert.AreNotEqual(0, result);
            Assert.AreEqual(0.743482F, result);
            Console.WriteLine("Result of DotProduct invocation: {0}", result);
        }

        [TestMethod]
        public void NextRandomFloatTest()
        {
            // Arrange
            Random random = new Random();

            // Act
            float nextRandomFloat = random.NextFloat();

            // Assert
            Assert.AreEqual(typeof (float), nextRandomFloat.GetType());
            Assert.AreNotEqual(0, nextRandomFloat);
            Console.WriteLine("Result of NextFloat invocations: {0}", nextRandomFloat);
        }
    }
}
