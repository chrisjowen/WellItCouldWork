using System;
using NUnit.Framework;
using WellItCouldWork.Investigation;
using WellItCouldWork.Tests.TestSyntaxHelpers;

namespace WellItCouldWork.Tests.Investigation
{
    [TestFixture]
    public class ProjectTests
    {
        private ProjectFile projectFile;

        [SetUp]
        public void BeforeEachTest()
        {
            const string projectSampleLocation = @"TestData/WellItCouldWork/WellItCouldWork.csproj";
            projectFile = ProjectFile.FromFile(projectSampleLocation);
        }

        [Test]
        public void ShouldTellMeTheProjectsNameAndLocation()
        {
            Assert.That(projectFile.ProjectName, Is.EqualTo("WellItCouldWork.csproj"));
            Assert.That(projectFile.ProjectLocation, Is.EqualTo(Environment.CurrentDirectory + "\\TestData\\WellItCouldWork"));
        }   

        [Test]
        public void ShouldTellMeTheExternalDependenciesAProjectReferences()
        {
            Assert.That(projectFile.HasAReferenceCalled("nunit.framework"));
        }         
        
        [Test]
        public void ShouldTellMeAboutTheClassesOfAProject()
        {
            Assert.That(projectFile.HasAClassCalled("ClassInfo.cs"));
        }        
    }
}
    