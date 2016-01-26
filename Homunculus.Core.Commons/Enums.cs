using Homunculus.Core.Interfaces;

namespace Homunculus.Core.Commons
{
    public static class Enums
    {
        /// <summary>
        /// Used by implementations of <see cref="INeuron"/> to send signals.
        /// </summary>
        public enum NeuronSignals
        {
            InputReceived,
            InputActorsReceived,
            OutputActorsReceived,
            SignalFault
        }
    }
}