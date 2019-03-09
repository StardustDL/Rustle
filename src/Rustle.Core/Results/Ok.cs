using System;
using System.Collections.Generic;

namespace Rustle.Core.Results
{
    public sealed class Ok<T, E> : Result<T, E>
    {
        public T Value { get; private set; }

        public override bool IsErr => false;

        internal Ok(T value) => Value = value;

        public override T Unwrap() => Value;

        public override E UnwrapErr() => throw new Exception("Cannot unwrap err for Ok value.");

        public override bool Equals(Result<T, E> other) => !other.IsErr && EqualityComparer<T>.Default.Equals(other.Unwrap(), Value);
    }
}
