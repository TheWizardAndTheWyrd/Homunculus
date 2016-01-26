using System;
using System.Collections.Generic;
using Akka.Actor;

namespace Homunculus.Core.Interfaces
{
    /// <summary>
    /// The INeuron interface and its implementations form the basic building blocks
    /// of our Topology Weight Evolving Artificial Neural Networks.
    /// </summary>
    public interface INeuron
    {
        /// <summary>
        /// The globally unique Id of the INeuron instance.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// A collection of <see cref="IActorRef"/> instances representing
        /// this neuron's input origins.
        /// </summary>
        IEnumerable<IActorRef> InputActors { get; set; }

        /// <summary>
        /// TODO: Refactor to allow a <see cref="IEnumerable{T}"/> of Weights.
        /// The synaptic weights of this <see cref="INeuron"/> instance.
        /// </summary>
        Tuple<float?, float?, float?> Weights { get; set; }

        /// <summary>
        /// Calculate the DP of the Input and the Weights.
        /// </summary>
        float? DotProduct { get; set; }

        /// <summary>
        /// The <see cref="INeuron"/> instance's input from the InputActors.
        /// </summary>
        IEnumerable<float?> Input { get; set; }

        /// <summary>
        /// The Output forwarded to the OutputActors and used as the 
        /// OutputActors' Input in the feed-forward neural network.
        /// </summary>
        float? Output { get; }

        /// <summary>
        /// A collection of <see cref="IActorRef"/> to send our Output to.
        /// </summary>
        IEnumerable<IActorRef> OutputActors { get; set; }

        /// <summary>
        /// Increments each time the ActivationFunction is invoked.
        /// </summary>
        int Accumulator { get; set; }

        /// <summary>
        /// Tunable asymmetry that we can apply to our ActivationFunction invocation.
        /// </summary>
        float? Bias { get; set; }

        /// <summary>
        /// TODO: Cf. Gene Sher' reference material to determine the veracity of this summary.
        /// If set, the threshold must be reached in order to forward the feed to the OutputActors.
        /// </summary>
        float? Threshold { get; set; }

        /// <summary>
        /// Process our Input and create our Output.
        /// </summary>
        /// <param name="dotProduct"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        float? ActivationFunction(float? dotProduct, float? threshold);
    }
}