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
        private float _input;
        #endregion

        #region [ Public Properties ]
        public Tuple<float, float, float> Weights
        {
            get { return _weights; }
            set { _weights = value; }
        }

        public float Input
        {
            get { return _input; }
            set { _input = value; }
        }

        //public float Output
        //{
        //    get
        //    {
        //        return 
        //    }
        //}
        #endregion

        #region [ Constructors ]
        public Neuron(int seed, Tuple<float, float, float> weights)
        {
            _random = new Random(seed);
            _weights = weights;
        }

        public Neuron(int seed)
        {
            _random = new Random(seed);
            _weights = new Tuple<float, float, float>(_random.NextFloat(), _random.NextFloat(), _random.NextFloat());
        }
        #endregion
        
    }
}
