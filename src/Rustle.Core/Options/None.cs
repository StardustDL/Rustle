using System;
using System.Collections.Generic;

namespace Rustle.Core.Options
{
    public sealed class None<T> : Option<T>
    {
        internal None() { }

        static None<T> _default = null;

        static internal None<T> Default
        {
            get
            {
                if (_default == null) _default = new None<T>();
                return _default;
            }
        }

        public override bool IsNone => true;

        public override bool Equals(Option<T> other) => other.IsNone;

        public override T Unwrap() => throw new Exception("Cannot unwrap from a none value.");
    }
}
