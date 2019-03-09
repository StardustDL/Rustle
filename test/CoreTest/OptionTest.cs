using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rustle.Core.Options;

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
            Assert.AreEqual(some0.Unwrap(), 0);
            Assert.AreEqual(some0.Or(none), some0);
            Assert.AreEqual(some0.Or(some1), some0);
            Assert.AreEqual(none.Or(some0), some0);
            Assert.AreEqual(none.And(some0), none);
            Assert.AreEqual(some0.And(some1), some1);
            Assert.AreEqual(some0.Xor(some1), none);
            Assert.AreEqual(none.Xor(none), none);
            Assert.AreEqual(some0.Xor(none), some0);
            Assert.AreEqual(none.Xor(some0), some0);
        }
    }
}
