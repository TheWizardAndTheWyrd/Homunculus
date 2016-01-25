using System;
using Homunculus.Core.Interfaces.Enums;

namespace Homunculus.Core.Interfaces.Actors.Messages
{
    public interface IGenericExpressionMessage<TResult>
    {
        MessageTypes.GenericExpression MessageType { get; set; }

        Func<TResult> Value { get; set; } 
    }

    public interface IGenericExpressionMessage<T, TResult>
    {
        MessageTypes.GenericExpression MessageType { get; set; }

        Func<T, TResult> Value { get; set; }
    }

    public interface IGenericExpressionMessage<T1, T2, TResult>
    {
        MessageTypes.GenericExpression MessageType { get; set; }

        Func<T1, T2, TResult> Value { get; set; } 
    }

    public interface IGenericExpressionMessage<T1, T2, T3, TResult>
    {
        MessageTypes.GenericExpression MessageType { get; set; }

        Func<T1, T2, T3, TResult> Value { get; set; } 
    }

    public interface IGenericExpressionMessage<T1, T2, T3, T4, TResult>
    {
        MessageTypes.GenericExpression MessageType { get; set; }

        Func<T1, T2, T3, T4, TResult> Value { get; set; } 
    }

    public interface IGenericExpressionMessage<TResult, T1, T2, T3, T4, T5>
    {
        MessageTypes.GenericExpression MessageType { get; set; }

        Func<T1, T2, T3, T4, T5, TResult> Value { get; set; }
    }
}