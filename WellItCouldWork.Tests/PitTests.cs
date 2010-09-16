using System;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Core;
using NUnit.Framework;

namespace WellItCouldWork.Tests
{
    [TestFixture]
    public class PitTests
    {
        [Test]
        public void CanLoadCorrectShit()
        {
            var runner = new SimpleTestRunner();
            var assemblies = new List<AssemblyName>
                                 {
                                     new AssemblyName(@"C:\Code\WellItCouldWork\WellItCouldWork.Tests\TestData\test-assembly.dll") 

                                 };
            var package = new TestPackage("somePackage", assemblies);
            runner.Load(package);
            runner.Run(new ConsoleEventListener());
        }
    }



    public class ConsoleEventListener : EventListener
    {
        public void RunStarted(string name, int testCount)
        {
            Console.WriteLine("Started running " + name);
        }

        public void RunFinished(TestResult result)
        {
            Console.WriteLine(result.ToString());
        }

        public void RunFinished(Exception exception)
        {
            Console.WriteLine("Started running " + exception);
        }
        
        public void TestStarted(TestName testName)
        {
            Console.WriteLine("Test started " + testName);
        }

        public void TestFinished(TestResult result)
        {
            Console.WriteLine("Test finished " + result);
        }

        public void SuiteStarted(TestName testName)
        {
            Console.WriteLine("Suite Started " + testName);
        }

        public void SuiteFinished(TestResult result)
        {
            Console.WriteLine("Suite finished " + result);
        }

        public void UnhandledException(Exception exception)
        {
            Console.WriteLine("Exception " + exception);
        }

        public void TestOutput(TestOutput testOutput)
        {
            Console.WriteLine("Exception " + testOutput);

        }
    }
}
