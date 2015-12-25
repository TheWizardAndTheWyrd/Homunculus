using System;
using Akka.Actor;

namespace Homunculus.Core.Interfaces
{
    /// <summary>
    /// TODO: Rewrite this summary after the interface is fleshed out and an implementation is complete.
    /// The IActuator gathers the control signals from the <see cref="INeuron"/> and appends them
    /// to the accumulator.  The order in which the signals are accumulated into a vector is the same
    /// order as the <see cref="INeuron"/> Ids are stored within NIds.  Once all of the signal have been
    /// gathered, the <see cref="IActuator"/> sends the <see cref="ICortex"/> the sync signal, executes
    /// its function, and then again begins to wait for neural signals from output layer by resetting the
    /// FanInActorIds from the second copy of the list. 
    /// </summary>
    public interface IActuator
    {
        Guid Id { get; }

        /// <summary>
        /// When invoked, Generate immediately spawns an <see cref="IActuator"/> and waits for its intial state.
        /// </summary>
        /// <param name="exoSelfId"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        IActorRef Generate(Guid exoSelfId, IActorRef node);

        object Prepare(Guid exoSelfId);

        void PrintToSscreen();
    }
}