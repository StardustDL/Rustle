using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rustle.Core;
using Rustle.Core.Results;
using System;

namespace CoreTest
{
    [TestClass]
    public class ResultTest
    {
        [TestMethod]
        public void OkErr()
        {
            Result<int, Unit> res0 = Result.Ok<int, Unit>(0), res1 = Result.Ok<int, Unit>(1), err = Result.Err<int, Unit>(Unit.Default);
            Assert.IsFalse(res0.IsErr);
            Assert.IsTrue(res1.IsOk);
            Assert.AreEqual(0, res0.Unwrap());
            Assert.AreEqual(res0, res0.Or(err));
            Assert.AreEqual(res0, res0.Or(res1));
            Assert.AreEqual(res0, err.Or(res0));
            Assert.AreEqual(err.UnwrapErr(), err.And(res0).UnwrapErr());
            Assert.AreEqual(res1, res0.And(res1));

            Assert.AreEqual(0, res1.Match(_ => 0, _ => 1));
            Assert.AreEqual(1, err.Match(_ => 0, _ => 1));
            Assert.ThrowsException<Exception>(() => res0.UnwrapErr());
            Assert.ThrowsException<Exception>(() => err.Unwrap());
        }
    }
}
