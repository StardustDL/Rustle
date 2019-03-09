using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rustle.Core.Options;
using Rustle.Core;
using System;

namespace CoreTest
{
    [TestClass]
    public class OptionTest
    {
        [TestMethod]
        public void SomeNone()
        {
            Option<int> some0 = Option.Some(0), some1 = Option.Some(1), none = Option.None<int>();
            Assert.IsFalse(some0.IsNone);
            Assert.IsTrue(some1.IsSome);
            Assert.AreEqual(0, some0.Unwrap());
            Assert.AreEqual(some0, some0.Or(none));
            Assert.AreEqual(some0, some0.Or(some1));
            Assert.AreEqual(some0, none.Or(some0));
            Assert.AreEqual(none, none.And(some0));
            Assert.AreEqual(some1, some0.And(some1));
            Assert.AreEqual(none, some0.Xor(some1));
            Assert.AreEqual(none, none.Xor(none));
            Assert.AreEqual(some0, some0.Xor(none));
            Assert.AreEqual(some0, none.Xor(some0));

            Assert.AreEqual(0, some1.Match(_ => 0, () => 1));
            Assert.AreEqual(1, none.Match(_ => 0, () => 1));
            Assert.ThrowsException<Exception>(() => none.Unwrap());
        }
    }
}
