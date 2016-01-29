using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Akka.Actor;
using Homunculus.Core.Interfaces;

namespace Homunculus.Core.Actors
{
    public class BlockExpressionActor<T, TResult> : ReceiveActor, INeuron
    {
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

        public BlockExpressionActor()
        {
            Receive<Tuple<BlockExpression, ParameterExpression>>(message =>
            {
                try
                {
                    var d = Expression.Lambda<Func<T, TResult>>(message.Item1, message.Item2).Compile();
                    Sender.Tell(Task.FromResult(d), Self);
                }
                catch (Exception e)
                {
                    Sender.Tell(new Failure { Exception = e }, Self);
                }
            });
        }

    }
}