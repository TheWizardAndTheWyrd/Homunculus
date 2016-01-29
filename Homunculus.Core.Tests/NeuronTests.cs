//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Homunculus.Core.Commons;
//using Homunculus.Core.Extensions;
//using Homunculus.Core.Interfaces;

//namespace Homunculus.Core.Tests
//{
//    [TestClass()]
//    public class NeuronTests
//    {
//        [TestMethod()]
//        public void NeuronTest()
//        {
//            // Arrange
//            INeuron neuron = new Neuron(seed: 1, accumulator: 0);
//            neuron.Input = new List<float>() {0.1234567F};

//            // Act
//            var result = neuron.Output;

//            // Assert
//            Assert.AreNotEqual(0, result);
//            Console.WriteLine("Using the following input:");
//            foreach (var i in neuron.Input)
//            {
//                Console.WriteLine("\t-- {0}", i);
//            }

//            Console.WriteLine("\nUsing the following Weights:"); //" {0}, {1}, {2}", neuron.Weights.Item1, neuron.Weights.Item2, neuron.Weights.Item3);
//            foreach (var w in neuron.Weights.ToList())
//            {
//                Console.WriteLine("\t-- {0}", w);
//            }

//            Console.WriteLine("\nThe result of calculating the Output of our INeuron implementation:\n\t-- {0}", result);
//        }
//    }
//}