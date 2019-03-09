using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rustle.Core;
using Rustle.Core.Results;

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
            Assert.AreEqual(res0.Unwrap(), 0);
            Assert.AreEqual(res0.Or(err), res0);
            Assert.AreEqual(res0.Or(res1), res0);
            Assert.AreEqual(err.Or(res0), res0);
            Assert.AreEqual(err.And(res0).UnwrapErr(), err.UnwrapErr());
            Assert.AreEqual(res0.And(res1), res1);
        }
    }
}
