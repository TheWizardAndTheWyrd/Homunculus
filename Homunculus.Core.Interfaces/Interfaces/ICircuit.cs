using System;
using System.Collections;
using System.Collections.Generic;

namespace Homunculus.Core.Interfaces
{
    public interface ICircuit
    {
        Guid Id { get; }

        IList<object> TotalWeights(ICircuit circuit);

        ICircuit CreateCircuit(Guid[] processIds, object circuitLayerSpec);

        ICircuit CreateInitialCircuit(object[] inputSpecs);

        object TransferCircuit(IActuator actuator, ICircuit circuit, object plasticity);

        ICircuit Validate(ICircuit circuit);

        object CalculateOutputDae(object vector, ICircuit circuit);

        object CalculateOutputDaeShort(object vector, ICircuit circuit);

        object CalculateOutputLrfDae(object vector, ICircuit circuit);

        object CalculateOutputLrfDaeShort(object vector, ICircuit circuit);

        object CalculateOutputSdae(object vector, ICircuit circuit);
    }
}