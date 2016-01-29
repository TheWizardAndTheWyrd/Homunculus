using System;
using System.Collections.Generic;

namespace Homunculus.Core.Commons.Exceptions
{
    public class NeuronActivatorException : Exception
    {
        public NeuronActivatorException()
        {
            
        }

        public NeuronActivatorException(string message) 
            : base(message)
        {
            
        }

        public NeuronActivatorException(string message, Exception inner)
            : base(message, inner)
        {
            
        }
    }
}
