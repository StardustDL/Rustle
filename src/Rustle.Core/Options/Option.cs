using Rustle.Core.Results;
using System;
using System.Collections.Generic;

namespace Rustle.Core.Options
{
    public abstract class Option<T> : IEquatable<Option<T>>
    {
        public abstract bool IsNone { get; }

        public abstract T Unwrap();

        public abstract bool Equals(Option<T> other);

        public bool IsSome => !IsNone;

        public T Except(Exception exception) => IsNone ? throw exception : Unwrap();

        public T UnwrapOr(T def) => IsNone ? def : Unwrap();

        public Result<T, E> OkOr<E>(E err) => IsNone ? (Result<T, E>)new Err<T, E>(err) : new Ok<T, E>(Unwrap());

        public Option<U> And<U>(Option<U> other) => IsNone ? Option.None<U>() : other;

        public Option<T> Or(Option<T> other) => IsNone ? other : this;

        public Option<T> Xor(Option<T> other) => IsNone == other.IsNone ? Option.None<T>() : (IsNone ? other : this);
    }

    public static class Option
    {
        public static Option<T> Some<T>(T value) => new Some<T>(value);

        public static Option<T> None<T>() => Options.None<T>.Default;
    }
}
