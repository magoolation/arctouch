using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArcTouchApp.UnitTests
{
    [TestClass]
    public class MiscTests
    {
        [TestMethod]
        public void Must_Pass()
        {
            int expected = 1;
            int actual = 1;

            Assert.AreEqual(expected, actual);
        }
    }
}
