using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Akka.Actor;
using Homunculus.Core.Interfaces.Actors.Messages;

namespace Homunculus.Core.Actors
{
    public class ExpressionTreeActor<TResult> : ReceiveActor
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
    }
}