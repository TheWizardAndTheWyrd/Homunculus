using System;
using System.Collections.Generic;
using System.Linq;
using Akka.Actor;
using Akka.Event;
using Homunculus.Core.Commons;
using Homunculus.Core.Extensions;
using Homunculus.Core.Interfaces;
using Newtonsoft.Json;

namespace Homunculus.Core.Actors
{
    /// <summary>
    /// Our INeuron implementations all follow the same basic logical signal flow:
    ///     1. Accept Input signals.
    ///     2. Weighs each Input by finding the dot product of the Input and the Weights.
    ///     3. Add a bias to the DotProduct (used for tunable asymmetry).
    ///     4. Apply the DotProduct and the Threshold to the ActivationFunction.
    ///     5. Forward to the Output to the next INeurons in the neural network.
    /// </summary>
    public class NeuronActor : ReceiveActor, INeuron
    {
        #region [ Private Fields ]

        private readonly ILoggingAdapter _log = Context.GetLogger();
        
        #endregion

        #region [ Public Properties ]
        
        /// <summary>
        /// Our Id is unique and immutable.
        /// </summary>
        public Guid Id { get; }

        public IEnumerable<IActorRef> InputActors { get; set; }

        //public Tuple<float?, float?, float?> Weights { get; set; }
        public IEnumerable<float> Weights { get; set; } 

        public float? DotProduct { get; set; }

        public IEnumerable<float> Input { get; set; }

        public float? Output { get; set; }

        public IEnumerable<IActorRef> OutputActors { get; set; }

        public float Accumulator { get; set; }

        public float? Bias { get; set; }

        public float? Threshold { get; set; }
        
        #endregion

        #region [ Public Methods ]

        /// <summary>
        /// TODO: Make the ActivationFunction a Func{T} that can be received/swappable.
        /// </summary>
        /// <param name="dotProduct"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public float? ActivationFunction(float? dotProduct, float? threshold)
        {
            double result = Math.Tanh((Convert.ToDouble(DotProduct)) + Convert.ToDouble(Accumulator));
            return (float) result;
            //throw new NotImplementedException();
        }

        #endregion

        #region [ Constructors ]

        private void InitializeNeuronActor()
        {
            try
            {
                this.InputActors = new List<IActorRef>();
                this.OutputActors = new List<IActorRef>();
                //this.Weights = new Tuple<float?, float?, float?>(null, null, null);
                this.Weights = new List<float>();
                this.DotProduct = null;
                this.Input = new List<float>();
                this.Output = null;
                this.Accumulator = 0;
                this.Bias = null;
                this.Threshold = null;
            }
            catch (Exception e)
            {
                _log.Error(e, $"[{DateTime.Now}] Invocation of InitializeNeuronActor() threw an exception when instantiated by: {Sender}");
            }
        }

        public NeuronActor()
        {
            #region [ Setup Initial Actor State ]

            this.Id = Guid.NewGuid();
            this.InitializeNeuronActor();

            #endregion

            #region [ Property Receivers ]

            // Receive and process IEnumerable<IActorRef> for either InputActors or OutputActors.
            // If we can't process the message, log a warning and send a Enums.NeuronSignals.SignalFault.
            Receive<Tuple<Enums.NeuronSignals, IEnumerable<IActorRef>>>(m =>
            {
                switch (m.Item1)
                {
                    case Enums.NeuronSignals.InputActorsReceived:
                        this.InputActors.ToList().AddRange(m.Item2);
                        _log.Info($"[{DateTime.Now}] Received: {Enum.GetName(typeof(Enums.NeuronSignals), m.Item1)} with [{JsonConvert.SerializeObject(m.Item2)}] from: {Sender}");
                        Sender.Tell(new Tuple<Enums.NeuronSignals, Enums.NeuronSignals>(Enums.NeuronSignals.Ack, Enums.NeuronSignals.InputActorsReceived), Self);
                        break;

                    case Enums.NeuronSignals.OutputActorsReceived:
                        this.OutputActors.ToList().AddRange(m.Item2);
                        _log.Info($"[{DateTime.Now}] Received: {Enum.GetName(typeof(Enums.NeuronSignals), m.Item1)} with [{JsonConvert.SerializeObject(m.Item2)}] from: {Sender}");
                        Sender.Tell(new Tuple<Enums.NeuronSignals, Enums.NeuronSignals>(Enums.NeuronSignals.Ack, Enums.NeuronSignals.OutputActorsReceived), Self);
                        break;

                    default:
                        _log.Warning($"[{DateTime.Now}] Invalid NeuronSignal Received: ${Enum.GetName(typeof(Enums.NeuronSignals), m.Item1)} with [{JsonConvert.SerializeObject(m.Item2)}] from: {Sender}");
                        Sender.Tell(new Tuple<Enums.NeuronSignals, Enums.NeuronSignals>(Enums.NeuronSignals.Ack, Enums.NeuronSignals.SignalFault), Self);
                        break;
                }
            });

            //Receive<Tuple<Enums.NeuronSignals, float>>(m =>
            //{

            //});

            Receive<Tuple<Enums.NeuronSignals, float?>>(m =>
            {
                switch (m.Item1)
                {
                    case Enums.NeuronSignals.BiasReceived:
                        this.Bias = m.Item2;
                        _log.Info($"[{DateTime.Now}] Received: {Enum.GetName(typeof(Enums.NeuronSignals), m.Item1)} with [{JsonConvert.SerializeObject(m.Item2)}] from: {Sender}");
                        Sender.Tell(new Tuple<Enums.NeuronSignals, Enums.NeuronSignals>(Enums.NeuronSignals.Ack, Enums.NeuronSignals.BiasReceived), Self);
                        break;

                    case Enums.NeuronSignals.ThresholdReceived:
                        this.Threshold = m.Item2;
                        _log.Info($"[{DateTime.Now}] Received: {Enum.GetName(typeof(Enums.NeuronSignals), m.Item1)} with [{JsonConvert.SerializeObject(m.Item2)}] from: {Sender}");
                        Sender.Tell(new Tuple<Enums.NeuronSignals, Enums.NeuronSignals>(Enums.NeuronSignals.Ack, Enums.NeuronSignals.ThresholdReceived), Self);
                        break;

                    case Enums.NeuronSignals.AccumulatorReceived:
                        this.Accumulator = (float)m.Item2;
                        _log.Info($"[{DateTime.Now}] Received: {Enum.GetName(typeof(Enums.NeuronSignals), m.Item1)} with [{JsonConvert.SerializeObject(m.Item2)}] from: {Sender}");
                        Sender.Tell(new Tuple<Enums.NeuronSignals, Enums.NeuronSignals>(Enums.NeuronSignals.Ack, Enums.NeuronSignals.AccumulatorReceived), Self);
                        break;

                    case Enums.NeuronSignals.InputReceived:
                        if (this.InputActors.ToList().Contains(Sender))
                        {
                            this.Input.ToList().Add((float) m.Item2);
                            _log.Info($"[{DateTime.Now}] Received: {Enum.GetName(typeof(Enums.NeuronSignals), m.Item1)} with [{JsonConvert.SerializeObject(m.Item2)}] from: {Sender}");
                            Sender.Tell(new Tuple<Enums.NeuronSignals, Enums.NeuronSignals>(Enums.NeuronSignals.Ack, Enums.NeuronSignals.InputReceived), Self);
                        }
                        break;

                    default:
                        _log.Warning($"[{DateTime.Now}] Invalid NeuronSignal Received: ${Enum.GetName(typeof(Enums.NeuronSignals), m.Item1)} with [{JsonConvert.SerializeObject(m.Item2)}] from: {Sender}");
                        Sender.Tell(new Tuple<Enums.NeuronSignals, Enums.NeuronSignals>(Enums.NeuronSignals.Ack, Enums.NeuronSignals.SignalFault), Self);
                        break;
                }
            });

            //Receive<Tuple<Enums.NeuronSignals, Tuple<float?, float?, float?>>>(m =>
            Receive<Tuple<Enums.NeuronSignals, IEnumerable<float>>>(m =>
            {
                switch (m.Item1)
                {
                    case Enums.NeuronSignals.WeightsReceived:
                        this.Weights = m.Item2;
                        _log.Info($"[{DateTime.Now}] Received: {Enum.GetName(typeof(Enums.NeuronSignals), m.Item1)} with [{JsonConvert.SerializeObject(m.Item2)}] from: {Sender}");
                        Sender.Tell(new Tuple<Enums.NeuronSignals, Enums.NeuronSignals>(Enums.NeuronSignals.Ack, Enums.NeuronSignals.WeightsReceived), Self);
                        break;

                    default:
                        _log.Warning($"[{DateTime.Now}] Invalid NeuronSignal Received: ${Enum.GetName(typeof(Enums.NeuronSignals), m.Item1)} with [{JsonConvert.SerializeObject(m.Item2)}] from: {Sender}");
                        Sender.Tell(new Tuple<Enums.NeuronSignals, Enums.NeuronSignals>(Enums.NeuronSignals.Ack, Enums.NeuronSignals.SignalFault), Self);
                        break;
                }
            });

            Receive<Enums.NeuronSignals>(m =>
            {
                switch (m)
                {
                    case Enums.NeuronSignals.CalculateDotProduct:
                        if (this.Input != null && this.Weights != null)
                        {
                            try
                            {
                                this.DotProduct = (this.Input.DotProduct(this.Weights, this.Accumulator)) + this.Bias;
                                Sender.Tell(
                                    new Tuple<Enums.NeuronSignals, float?>(Enums.NeuronSignals.CalculateDotProduct,
                                        this.DotProduct), Self);
                            }
                            catch (Exception e)
                            {
                                _log.Error(e,
                                    $"[{DateTime.Now}] Sending of {m} threw an exception when instantiated by: {Sender}");
                                Sender.Tell(new Tuple<Enums.NeuronSignals, Enums.NeuronSignals>(Enums.NeuronSignals.Ack, Enums.NeuronSignals.SignalFault), Self);
                            }
                        }
                        else
                        {
                            _log.Warning($"[{DateTime.Now}] One of the inputs of the DotProduct function is null when invoked by {Sender}.  this.Input: {this.Input}  this.Weights: {this.Weights}");
                            Sender.Tell(new Tuple<Enums.NeuronSignals, Enums.NeuronSignals>(Enums.NeuronSignals.Ack, Enums.NeuronSignals.SignalFault), Self);
                        }
                        break;

                    case Enums.NeuronSignals.InvokeActivationFunction:
                        _log.Info($"[{DateTime.Now}] Received: {Enum.GetName(typeof(Enums.NeuronSignals), m)} from: {Sender}");
                        this.Output = this.ActivationFunction(this.DotProduct, this.Threshold);
                        Sender.Tell(new Tuple<Enums.NeuronSignals, Enums.NeuronSignals>(Enums.NeuronSignals.Ack, Enums.NeuronSignals.InvokeActivationFunction), Self);
                        break;

                    case Enums.NeuronSignals.ForwardOutput:
                        _log.Info($"[{DateTime.Now}] Received: {Enum.GetName(typeof(Enums.NeuronSignals), m)} from: {Sender}");
                        ForwardOutputToOutputNeurons();
                        Sender.Tell(new Tuple<Enums.NeuronSignals, Enums.NeuronSignals>(Enums.NeuronSignals.Ack, Enums.NeuronSignals.ForwardOutput), Self);
                        break;

                    default:
                        _log.Warning($"[{DateTime.Now}] Unprocessable NeuronSignal Received: ${Enum.GetName(typeof(Enums.NeuronSignals), m)} from: {Sender}");
                        Sender.Tell(new Tuple<Enums.NeuronSignals, Enums.NeuronSignals>(Enums.NeuronSignals.Ack, Enums.NeuronSignals.SignalFault), Self);
                        break;
                }
            });

            #endregion
        }

        #endregion

        #region [ Helper Methods ]

        private void ForwardOutputToOutputNeurons()
        {
            foreach (var a in OutputActors)
            {
                _log.Info($"[{DateTime.Now}] Sending Output to next Neuron: {this.Output} from: {Self} to: {a}");
                a.Tell(new Tuple<Enums.NeuronSignals, float>(Enums.NeuronSignals.InputReceived, (float)this.Output));
            }
        }

        #endregion
    }
}