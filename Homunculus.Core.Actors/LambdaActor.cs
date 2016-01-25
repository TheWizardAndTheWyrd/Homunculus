using System;
using System.Threading.Tasks;
using Akka.Actor;
using Homunculus.Core.Interfaces.Actors.Messages;

namespace Homunculus.Core.Actors
{
    public class LambdaActor<TResult> : ReceiveActor
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
    }

    public class LambdaActor<T, TResult> : ReceiveActor
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
    }

    public class LambdaActor<T1, T2, TResult> : ReceiveActor
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
    }

    public class LambdaActor<T1, T2, T3, TResult> : ReceiveActor
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
    }

    public class LambdaActor<T1, T2, T3, T4, TResult> : ReceiveActor
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
    }

    public class LambdaActor<TResult, T1, T2, T3, T4, T5> : ReceiveActor
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
    }
}
