using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rustle.Core.Iterators
{
    public static class Iterator
    {
        public static IEnumerable<T> FromEnumerator<T>(this IEnumerator<T> enumerator)
        {
            do
            {
                yield return enumerator.Current;
            } while (enumerator.MoveNext());
        }

        public static int Count<T>(this IEnumerator<T> enumerator) => FromEnumerator(enumerator).Count();
    }
}
