using Homunculus.Core.Extensions;
using System;
using System.Collections.Generic;
using Homunculus.Core.Interfaces;

namespace Homunculus.Core
{
    public class Neuron : INeuron
    {
        #region [ Private Fields ]
        private Random _random;

        #endregion

        #region [ Public Properties ]

        public Guid Id { get; private set; }
        public Tuple<float, float, float> Weights { get; set; }

        public IEnumerable<float> Input { get; set; }

        public double Output => Math.Tanh(Input.DotProduct(Weights.ToList(), Accumulator));

        public int Accumulator { get; set; } = 0;

        #endregion

        #region [ Constructors ]
        public Neuron(int seed, Tuple<float, float, float> weights = null, int accumulator = 0)
        {
            _random = new Random(seed);

            Weights = weights ??
                       new Tuple<float, float, float>(_random.NextFloat(), 
                                                      _random.NextFloat(), 
                                                      _random.NextFloat());

            Accumulator = accumulator;

            Id = Guid.NewGuid();
        }

        public Neuron(int seed, int accumulator = 0)
        {
            _random = new Random(seed);

            Weights = new Tuple<float, float, float>(_random.NextFloat(), _random.NextFloat(), _random.NextFloat());

            Accumulator = accumulator;

            Id = Guid.NewGuid();
        }
        #endregion
        
    }
}
