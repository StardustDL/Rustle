using System;
using System.Collections.Generic;
using System.Text;

namespace Rustle.Result
{
    public abstract class Result<T, E>
    {
        public abstract bool IsErr { get; }

        public abstract T Unwrap();

        public abstract E UnwrapErr();

        public bool IsOk => !IsErr;

        public T Expect(Exception exception) => IsErr ? throw exception : Unwrap();

        public E ExpectErr(Exception exception) => IsErr ? UnwrapErr() : throw exception;
    }

    public sealed class Ok<T, E> : Result<T, E>
    {
        public T Value { get; private set; }

        public override bool IsErr => false;

        public Ok(T value) => Value = value;

        public override T Unwrap() => Value;

        public override E UnwrapErr() => throw new Exception("Cannot unwrap err for Ok value.");
    }

    public sealed class Err<T, E> : Result<T, E>
    {
        public E Value { get; private set; }

        public override bool IsErr => true;

        public Err(E value) => Value = value;

        public override T Unwrap() => throw new Exception("Cannot unwrap err for Err value.");

        public override E UnwrapErr() => Value;
    }
}
