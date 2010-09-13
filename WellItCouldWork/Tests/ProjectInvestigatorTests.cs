using NUnit.Framework;

namespace WellItCouldWork.Tests
{
    [TestFixture]
    public class ProjectInvestigatorTests
    {
        [Test]
        public void ShouldTellYouTheExternalDependenciesAProjectReferences()
        {
            var investigator = ProjectInvestigator.InvestigateProject(@"../../WellItCouldWork.csproj");
            var dependencies = investigator.TellMeAboutTheExternalDependencies();
            Assert.That(dependencies.HasADependencyCalled("nunit.framework"));
        }
    }
}
    