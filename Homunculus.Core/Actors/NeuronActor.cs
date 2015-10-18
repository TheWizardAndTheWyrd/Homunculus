using System;
using Akka.Actor;

namespace Homunculus.Core.Actors
{
    public class NeuronActor : ReceiveActor
    {
        public NeuronActor()
        {
            //Receive<Neuron>(neuron =>
            //    Console.WriteLine("The result of our Neuron DotProduct: {0}", neuron.));
        }
    }
}