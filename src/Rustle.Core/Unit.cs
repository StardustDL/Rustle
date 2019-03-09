using System;
using System.Collections.Generic;
using System.Text;

namespace Rustle.Core
{
    public sealed class Unit : IEquatable<Unit>
    {
        static readonly Unit _default = new Unit();

        private Unit() { }

        public static Unit Default => _default;

        public bool Equals(Unit other) => true;
    }
}
