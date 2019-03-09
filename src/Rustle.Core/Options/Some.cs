using System;
using System.Collections.Generic;

namespace Rustle.Core.Options
{
    public sealed class Some<T> : Option<T>
    {
        public T Value { get; private set; }

        public override bool IsNone => false;

        internal Some(T value) => Value = value;

        public override T Unwrap() => Value;

        public override bool Equals(Option<T> other) => !other.IsNone && EqualityComparer<T>.Default.Equals(other.Unwrap(), Value);
    }
}
