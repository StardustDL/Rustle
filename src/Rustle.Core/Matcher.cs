using Rustle.Core.Options;
using Rustle.Core.Results;
using System;

namespace Rustle.Core
{
    public static class Matcher
    {
        public static TResult Match<TSource, TResult>(this Option<TSource> option, Func<TSource, TResult> some, Func<TResult> none)
        {
            switch (option)
            {
                case Some<TSource> os:
                    return some(os.Value);
                case None<TSource> on:
                    return none();
                default:
                    throw new NotSupportedException();
            }
        }

        public static TResult Match<TOk, TErr, TResult>(this Result<TOk, TErr> result, Func<TOk, TResult> ok, Func<TErr, TResult> err)
        {
            switch (result)
            {
                case Ok<TOk, TErr> rok:
                    return ok(rok.Value);
                case Err<TOk, TErr> rerr:
                    return err(rerr.Value);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
