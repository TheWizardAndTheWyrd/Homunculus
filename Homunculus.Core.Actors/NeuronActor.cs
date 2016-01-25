using System;
using Akka.Actor;
using Akka.Event;
using Homunculus.Core.Commons;
using Homunculus.Core.Interfaces;

namespace Homunculus.Core.Actors
{
    public class NeuronActor : ReceiveActor
    {
        private readonly ILoggingAdapter _log = Context.GetLogger();

        public NeuronActor()
        {
            Receive<INeuron>(neuron =>
            {
                // Successive invocations of neuron.Output might mutate state.
                var neuronOutput = neuron.Output;

                Console.WriteLine("Neuron Output: {0}", ((Neuron)neuron).Output);

                Sender.Tell(neuronOutput, Self);

                _log.Info("The result of our neuron's computation: {0}", neuronOutput);
            });
        }
    }
}