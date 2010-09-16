using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace WellItCouldWork.Tests.TestRunner
{
    [TestFixture]
    public class NunitTestRunnerTests
    {
        public void ShouldRunTestsFromAssembly()
        {
            var testRunner = new NunitTestRunner("TestData/test-assembly.dll");
        }
    }

    public class NunitTestRunner
    {
        public NunitTestRunner(string testdataTestAssemblyDll)
        {
            throw new NotImplementedException();
        }
    }
}
