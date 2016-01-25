using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Akka.Actor;

namespace Homunculus.Core.Actors
{
    public class BlockExpressionActor<T, TResult> : ReceiveActor
    {
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