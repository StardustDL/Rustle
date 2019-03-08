using System;

namespace Rustle.Option
{
    public abstract class Option<T>
    {
        public abstract bool IsNone { get; }

        public abstract T Unwrap();

        public bool IsSome => !IsNone;

        public T Except(Exception exception) => IsNone ? throw exception : Unwrap();

        public T UnwrapOr(T def) => IsNone ? def : Unwrap();
    }

    public sealed class Some<T> : Option<T>
    {
        public T Value { get; private set; }

        public override bool IsNone => false;

        public Some(T value) => Value = value;

        public override T Unwrap() => Value;
    }

    public sealed class None<T> : Option<T>
    {
        public override bool IsNone => true;

        public override T Unwrap() => throw new Exception("Cannot unwrap from a none value.");
    }
}
