using System;
using System.Collections.Generic;

namespace Homunculus.Core.Interfaces
{
    /// <summary>
    /// TODO: Refactor, and consider breaking up the interface into smaller interfaces. 
    /// </summary>
    public interface IBenchmarker
    {
        Guid Id { get; }

        void PrintExperiment(Guid experimentId);

        object[] GetExperimentKeys();

        object Start(Guid id);

        object Start(Guid id, string[] notes);

        object Continue(Guid id);

        object Prepare(object experiment);

        object Loop(object experiment, Guid processId);

        object Report(Guid experimentId, string fileName);

        object Report(Guid experimentId, string fileName, int evalLimit);

        object[] PrepareGraphs(object[] traces);

        object[] WriteGraphs(object[] graphs, object graphPostfix);

        object Unconsult(IList<object> objList);

        object GenPlot(IList<object> objList, object[] accumulator1, object[] accumulator2, object[] accumulator3);

        object TraceToGraph(string fileName);

        object[] GetEvaluations(Guid experimentId, object fitnessGoal, int evalLimit);

        object ChangeMorph(Guid id, object newMorph);

        bool VectorGreaterThan(object vector1, object vector2);

        bool VectorLessThan(object vector1, object vector2);

        bool VectorEquals(object vector1, object vector2);
    }
}