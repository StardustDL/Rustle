using Rustle.Core.Options;
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

        public static IEnumerator<T> Filter<T>(this IEnumerator<T> enumerator, Func<T, bool> predicate) => FromEnumerator(enumerator).Where(predicate).GetEnumerator();

        public static IEnumerator<U> Map<T, U>(this IEnumerator<T> enumerator, Func<T, U> mapper) => FromEnumerator(enumerator).Select(mapper).GetEnumerator();

        public static IEnumerator<T> Chain<T>(this IEnumerator<T> enumerator, IEnumerator<T> other) => FromEnumerator(enumerator).Concat(FromEnumerator(other)).GetEnumerator();

        public static IEnumerator<T> Skip<T>(this IEnumerator<T> enumerator, uint count) => FromEnumerator(enumerator).Skip((int)count).GetEnumerator();

        public static IEnumerator<T> Take<T>(this IEnumerator<T> enumerator, uint count) => FromEnumerator(enumerator).Take((int)count).GetEnumerator();

        public static bool All<T>(this IEnumerator<T> enumerator, Func<T, bool> predicate) => FromEnumerator(enumerator).All(predicate);

        public static bool Any<T>(this IEnumerator<T> enumerator, Func<T, bool> predicate) => FromEnumerator(enumerator).Any(predicate);

        public static IEnumerator<T> Reverse<T>(this IEnumerator<T> enumerator) => FromEnumerator(enumerator).Reverse().GetEnumerator();

        public static IEnumerator<U> Flatten<T, U>(this IEnumerator<T> enumerator) where T : IEnumerator<U> => FromEnumerator(enumerator).SelectMany(item => FromEnumerator(item)).GetEnumerator();

        public static TAcc Fold<T, TAcc>(this IEnumerator<T> enumerator, TAcc origin, Func<TAcc, T, TAcc> folder)
        {
            foreach(var item in FromEnumerator(enumerator))
                origin = folder(origin, item);
            return origin;
        }

        public static Option<T> Next<T>(this IEnumerator<T> enumerator)
        {
            if (enumerator.MoveNext())
                return Option.Some(enumerator.Current);
            else return Option.None<T>();
        }

        public static Option<T> Last<T>(this IEnumerator<T> enumerator)
        {
            if (enumerator.MoveNext())
            {
                var res = enumerator.Current;
                while (enumerator.MoveNext()) res = enumerator.Current;
                return Option.Some(res);
            }
            else return Option.None<T>();
        }
    }
}
