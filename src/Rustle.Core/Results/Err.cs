using System;
using System.Collections.Generic;

namespace Rustle.Core.Results
{
    public sealed class Err<T, E> : Result<T, E>
    {
        public E Value { get; private set; }

        public override bool IsErr => true;

        internal Err(E value) => Value = value;

        public override T Unwrap() => throw new Exception("Cannot unwrap err for Err value.");

        public override E UnwrapErr() => Value;

        public override bool Equals(Result<T, E> other) => other.IsErr && EqualityComparer<E>.Default.Equals(other.UnwrapErr(), Value);
    }
}
