using NUnit.Framework;
using WellItCouldWork.Investigation;
using WellItCouldWork.Tests.TestSyntaxHelpers;

namespace WellItCouldWork.Tests.Investigation
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
    