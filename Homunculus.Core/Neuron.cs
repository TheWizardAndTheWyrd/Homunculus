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
        #endregion

        #region [ Public Properties ]

        #endregion

        #region [ Constructors ]
        public Neuron(int seed, Tuple<float, float, float> weights)
        {
            _random = new Random(seed);
            _weights = weights;
            #endregion
        }
    }
}
