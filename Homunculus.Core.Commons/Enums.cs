using Homunculus.Core.Interfaces;

namespace Homunculus.Core.Commons
{
    public static class Enums
    {
        /// <summary>
        /// Used by implementations of <see cref="INeuron"/> to send signals.
        /// 
        /// Our INeuron implementations all follow the same basic logical signal flow:
        ///     1. Accept Input signals.
        ///     2. Weighs each Input by finding the dot product of the Input and the Weights.
        ///     3. Add a bias to the DotProduct (used for tunable asymmetry).
        ///     4. Apply the DotProduct and the Threshold to the ActivationFunction.
        ///     5. Forward to the Output to the next INeurons in the neural network.        
        /// </summary>
        public enum NeuronSignals
        {
            InputReceived,
            InputActorsReceived,
            OutputActorsReceived,
            AccumulatorReceived,
            BiasReceived,
            ThresholdReceived,
            WeightsReceived,
            CalculateDotProduct,
            ActivationFunctionReceived,
            InvokeActivationFunction,
            ForwardOutput,
            SignalFault
        }
    }
}