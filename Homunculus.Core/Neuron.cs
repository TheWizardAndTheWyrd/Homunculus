using Homunculus.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homunculus.Core
{
    public class Neuron
    {
        #region [ Private Fields ]
        private Random _random;
        private Tuple<float, float, float> _weights;
        private IEnumerable<float> _input;
        private int _accumulator = 0;
        #endregion

        #region [ Public Properties ]
        public Tuple<float, float, float> Weights
        {
            get { return _weights; }
            set { _weights = value; }
        }

        public IEnumerable<float> Input
        {
            get { return _input; }
            set { _input = value; }
        }

        public float Output => Input.DotProduct(Weights.ToList(), Accumulator);

        public int Accumulator
        {
            get { return _accumulator; }
            set { _accumulator = value; }
        }
        #endregion

        #region [ Constructors ]
        public Neuron(int seed, Tuple<float, float, float> weights, int accumulator = 0)
        {
            _random = new Random(seed);
            _weights = weights;
            _accumulator = accumulator;
        }

        public Neuron(int seed)
        {
            _random = new Random(seed);
            _weights = new Tuple<float, float, float>(_random.NextFloat(), _random.NextFloat(), _random.NextFloat());
        }
        #endregion
        
    }
}
