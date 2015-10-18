using System;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Routing;
using Homunculus.Core.Actors;
using Homunculus.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Homunculus.Core.Tests.Actors
{
    [TestClass]
    public class NeuronActorTests
    {
        private static ActorSystem _actorSystem;
        private static IActorRef _testActor;
        private static Props _props;

        [TestMethod]
        public void SendNeuronToActorSystem()
        {
            // Arrange
            INeuron neuronMessage = new Neuron(seed: 1, accumulator: 0);

            _actorSystem = ActorSystem.Create("neuronTestSystem");
            _props = Props.Create<NeuronActor>().WithRouter(new RoundRobinPool(5));
            _testActor = _actorSystem.ActorOf(_props, "neuron");

            // Act
            //Task<object> t = Task.Run(async () =>
            //{
            //    var t1 = _testActor.Ask(neuronMessage, TimeSpan.FromSeconds(1));

            //    await Task.WhenAll(t1);

            //    return t1.Result;
            //});

            _testActor.Tell(neuronMessage, _testActor);

            // Assert
            //Console.WriteLine("The result of sending our neuronActor to the neuronTestSystem: {0}", t.Result);
            Assert.Fail("The Actor System is not receiving neurons.  The actor system should probably spawn INeuron objects.");
        }
    }
}
