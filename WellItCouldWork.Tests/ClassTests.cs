﻿using NUnit.Framework;

namespace WellItCouldWork.Tests
{
    [TestFixture]
    public class ClassTests
    {
        [Test]
        public void CanSetFromImplicitStringConversion()
        {
            const string classname = "ClassName";
            var @class = new Class(classname);
            Assert.That(@class.ClassName, Is.EqualTo(classname));
        }

        [Test]
        public void ShouldFail()
        {
            Assert.True(false, "Failed on purpose");
        }
    }
}
