using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Akka.Actor;
using Homunculus.Core.Interfaces;
using Homunculus.Core.Interfaces.Actors.Messages;

namespace Homunculus.Core.Actors
{
    public class ExpressionTreeActor<TResult> : ReceiveActor, INeuron
    {
        public ExpressionTreeActor()
        {
            Receive<Expression<TResult>>(block =>
            {
                try
                {
                    var result = block.Compile();
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