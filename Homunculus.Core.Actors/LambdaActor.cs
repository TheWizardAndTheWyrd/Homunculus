using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Akka.Actor;
using Homunculus.Core.Interfaces;
using Homunculus.Core.Interfaces.Actors.Messages;

namespace Homunculus.Core.Actors
{
    public class LambdaActor<TResult> : ReceiveActor, INeuron
    {
        public LambdaActor()
        {
            Receive<IGenericExpressionMessage<TResult>>(message =>
            {
                try
                {
                    var result = Task.FromResult(message.Value);
                    Sender.Tell(result, Self);
                }
                catch (Exception e)
                {
                    Sender.Tell(new Failure{Exception = e}, Self);
                }
                
            });
        }

        public Guid Id { get; }
        public IEnumerable<IActorRef> InputActors { get; set; }
        public IEnumerable<float> Weights { get; set; }
        public float? DotProduct { get; set; }
        public IEnumerable<float> Input { get; set; }
        public float? Output { get; set; }
        public IEnumerable<IActorRef> OutputActors { get; set; }
        public float Accumulator { get; set; }
        public float? Bias { get; set; }
        public float? Threshold { get; set; }
        public float? ActivationFunction(float? dotProduct, float? threshold)
        {
            throw new NotImplementedException();
        }
    }

    public class LambdaActor<T, TResult> : ReceiveActor, INeuron
    {
        public LambdaActor()
        {
            Receive<IGenericExpressionMessage<T, TResult>>(message =>
            {
                try
                {
                    var result = Task.FromResult(message.Value);
                    Sender.Tell(result, Self);
                }
                catch (Exception e)
                {
                    Sender.Tell(new Failure {Exception = e}, Self);
                }
            });
        }

        public Guid Id { get; }
        public IEnumerable<IActorRef> InputActors { get; set; }
        public IEnumerable<float> Weights { get; set; }
        public float? DotProduct { get; set; }
        public IEnumerable<float> Input { get; set; }
        public float? Output { get; set; }
        public IEnumerable<IActorRef> OutputActors { get; set; }
        public float Accumulator { get; set; }
        public float? Bias { get; set; }
        public float? Threshold { get; set; }
        public float? ActivationFunction(float? dotProduct, float? threshold)
        {
            throw new NotImplementedException();
        }
    }

    public class LambdaActor<T1, T2, TResult> : ReceiveActor, INeuron
    {
        public LambdaActor()
        {
            Receive<IGenericExpressionMessage<T1, T2, TResult>>(message =>
            {
                try
                {
                    var result = Task.FromResult(message.Value);
                    Sender.Tell(result, Self);
                }
                catch (Exception e)
                {
                    Sender.Tell(new Failure {Exception = e}, Self);
                }
            });
        }

        public Guid Id { get; }
        public IEnumerable<IActorRef> InputActors { get; set; }
        public IEnumerable<float> Weights { get; set; }
        public float? DotProduct { get; set; }
        public IEnumerable<float> Input { get; set; }
        public float? Output { get; set; }
        public IEnumerable<IActorRef> OutputActors { get; set; }
        public float Accumulator { get; set; }
        public float? Bias { get; set; }
        public float? Threshold { get; set; }
        public float? ActivationFunction(float? dotProduct, float? threshold)
        {
            throw new NotImplementedException();
        }
    }

    public class LambdaActor<T1, T2, T3, TResult> : ReceiveActor, INeuron
    {
        public LambdaActor()
        {
            Receive<IGenericExpressionMessage<T1, T2, T3, TResult>>(message =>
            {
                try
                {
                    var result = Task.FromResult(message.Value);
                    Sender.Tell(result, Self);
                }
                catch (Exception e)
                {
                    Sender.Tell(new Failure {Exception = e}, Self);
                }
            });
        }

        public Guid Id { get; }
        public IEnumerable<IActorRef> InputActors { get; set; }
        public IEnumerable<float> Weights { get; set; }
        public float? DotProduct { get; set; }
        public IEnumerable<float> Input { get; set; }
        public float? Output { get; set; }
        public IEnumerable<IActorRef> OutputActors { get; set; }
        public float Accumulator { get; set; }
        public float? Bias { get; set; }
        public float? Threshold { get; set; }
        public float? ActivationFunction(float? dotProduct, float? threshold)
        {
            throw new NotImplementedException();
        }
    }

    public class LambdaActor<T1, T2, T3, T4, TResult> : ReceiveActor, INeuron
    {
        public LambdaActor()
        {
            Receive<IGenericExpressionMessage<T1, T2, T3, T4, TResult>>(message =>
            {
                try
                {
                    var result = Task.FromResult(message.Value);
                    Sender.Tell(result, Self);
                }
                catch (Exception e)
                {
                    Sender.Tell(new Failure {Exception = e}, Self);
                }
            });
        }

        public Guid Id { get; }
        public IEnumerable<IActorRef> InputActors { get; set; }
        public IEnumerable<float> Weights { get; set; }
        public float? DotProduct { get; set; }
        public IEnumerable<float> Input { get; set; }
        public float? Output { get; set; }
        public IEnumerable<IActorRef> OutputActors { get; set; }
        public float Accumulator { get; set; }
        public float? Bias { get; set; }
        public float? Threshold { get; set; }
        public float? ActivationFunction(float? dotProduct, float? threshold)
        {
            throw new NotImplementedException();
        }
    }

    public class LambdaActor<TResult, T1, T2, T3, T4, T5> : ReceiveActor, INeuron
    {
        public LambdaActor()
        {
            Receive<IGenericExpressionMessage<T1, T2, T3, T4, T5, TResult>>(message =>
            {
                try
                {
                    var result = Task.FromResult(message.Value);
                    Sender.Tell(result, Self);
                }
                catch (Exception e)
                {
                    Sender.Tell(new Failure {Exception = e}, Self);
                }
            });
        }

        public Guid Id { get; }
        public IEnumerable<IActorRef> InputActors { get; set; }
        public IEnumerable<float> Weights { get; set; }
        public float? DotProduct { get; set; }
        public IEnumerable<float> Input { get; set; }
        public float? Output { get; set; }
        public IEnumerable<IActorRef> OutputActors { get; set; }
        public float Accumulator { get; set; }
        public float? Bias { get; set; }
        public float? Threshold { get; set; }
        public float? ActivationFunction(float? dotProduct, float? threshold)
        {
            throw new NotImplementedException();
        }
    }
}
