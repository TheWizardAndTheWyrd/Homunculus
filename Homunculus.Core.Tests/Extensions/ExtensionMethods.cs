﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homunculus.Core.Extensions;

namespace Homunculus.Core.Tests.Extensions
{
    [TestClass]
    public class ExtensionMethods
    {
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
            Assert.AreEqual(0.05487416F, result);
            Console.WriteLine("Result of DotProduct invocation: {0}", result);
        }
    }
}