using System;
using Akka.Actor;
using Homunculus.Core.Interfaces;

namespace Homunculus.Core.Actors
{
    public class NeuronActor : ReceiveActor
    {
        public NeuronActor()
        {
            Receive<INeuron>(neuron =>
            {
                var neuronOutput = neuron.Output;
                Console.WriteLine("Neuron Output: {0}", ((Neuron)neuron).Output);
            });
        }
    }
}