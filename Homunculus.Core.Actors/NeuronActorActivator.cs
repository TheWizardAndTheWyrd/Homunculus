using System;
using System.Collections.Generic;
using Akka.Actor;
using Homunculus.Core.Commons.Exceptions;
using Homunculus.Core.Interfaces;

namespace Homunculus.Core.Actors
{
    public class NeuronActorActivator : IDisposable
    {
        public void InitializeNeuronActor(INeuron neuron)
        {
            try
            {
                neuron.InputActors = new List<IActorRef>();
                neuron.OutputActors = new List<IActorRef>();
                neuron.Weights = new List<float>();
                neuron.DotProduct = null;
                neuron.Input = new List<float>();
                neuron.Output = null;
                neuron.Accumulator = 0;
                neuron.Bias = null;
                neuron.Threshold = null;
            }
            catch (Exception e)
            {
                throw new NeuronActivatorException($"Unable to activate {neuron}", e);
            }
        }

        ~NeuronActorActivator()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                // TODO: Do we need to dispose anything?
            }
        }
    }
}