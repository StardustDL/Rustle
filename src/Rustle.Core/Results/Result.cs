using Rustle.Core.Options;
using System;

namespace Rustle.Core.Results
{
    public abstract class Result<T, E> : IEquatable<Result<T, E>>
    {
        public abstract bool IsErr { get; }

        public abstract T Unwrap();

        public abstract E UnwrapErr();

        public abstract bool Equals(Result<T, E> other);

        public bool IsOk => !IsErr;

        public T Expect(Exception exception) => IsErr ? throw exception : Unwrap();

        public E ExpectErr(Exception exception) => IsErr ? UnwrapErr() : throw exception;

        public Option<T> Ok() => IsErr ? Option.None<T>() : Option.Some(Unwrap());

        public Option<E> Err() => IsErr ? Option.Some(UnwrapErr()) : Option.None<E>();

        public Result<U, E> And<U>(Result<U, E> other) => IsErr ? Result.Err<U, E>(UnwrapErr()) : other;

        public Result<T, E> Or(Result<T, E> other) => IsErr ? other : this;
    }

    public static class Result
    {
        public static Result<T, E> Ok<T, E>(T value) => new Ok<T, E>(value);

        public static Result<T, E> Err<T, E>(E value) => new Err<T, E>(value);
    }
}
