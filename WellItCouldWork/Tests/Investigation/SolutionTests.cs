using System;
using System.Linq;
using NUnit.Framework;
using WellItCouldWork.Investigation;

namespace WellItCouldWork.Tests.Investigation
{
    [TestFixture]
    public class SolutionTests
    {
        [Test]
        public void ShouldRetrieveAllProjectsFromSolutionFile()
        {
            const string projectSampleLocation = @"Tests/TestData/WellItCouldWork.sln";
            var solution = new Solution(projectSampleLocation);
            Assert.That(solution.ContainsAProjectCalled("WellItCouldWork.csproj"));
            Assert.That(solution.Name, Is.EqualTo("WellItCouldWork.sln"));
            Assert.That(solution.Path, Is.EqualTo(Environment.CurrentDirectory + "\\Tests\\TestData"));
        }
    }

    public static class SolutionExt
    {
        public static bool ContainsAProjectCalled(this Solution solution, string projectName)
        {
            return solution.Projects.Any(p => p.ProjectName == projectName);
        }
    }
}
