using System;
using NUnit.Framework;
using WellItCouldWork.Investigation;
using WellItCouldWork.Tests.TestSyntaxHelpers;

namespace WellItCouldWork.Tests.Investigation
{
    [TestFixture]
    public class SolutionTests
    {
        [Test]
        public void ShouldRetrieveAllProjectsFromSolutionFile()
        {
            const string projectSampleLocation = @"TestData/WellItCouldWork.sln";
            var solution = new SolutionFile(projectSampleLocation);
            Assert.That(solution.ContainsAProjectCalled("WellItCouldWork.csproj"));
            Assert.That(solution.Name, Is.EqualTo("WellItCouldWork.sln"));
            Assert.That(solution.Path, Is.EqualTo(Environment.CurrentDirectory + "\\TestData"));
        }
    }
}
