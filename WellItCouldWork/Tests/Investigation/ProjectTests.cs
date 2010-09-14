using System;
using NUnit.Framework;
using WellItCouldWork.Investigation;
using WellItCouldWork.Tests.TestSyntaxHelpers;

namespace WellItCouldWork.Tests.Investigation
{
    [TestFixture]
    public class ProjectTests
    {
        private Project project;

        [SetUp]
        public void BeforeEachTest()
        {
            const string projectSampleLocation = @"Tests/TestData/WellItCouldWork/WellItCouldWork.csproj";
            project = Project.FromFile(projectSampleLocation);
        }

        [Test]
        public void ShouldTellMeTheProjectsNameAndLocation()
        {
            Assert.That(project.ProjectName, Is.EqualTo("WellItCouldWork.csproj"));
            Assert.That(project.ProjectLocation, Is.EqualTo(Environment.CurrentDirectory + "\\Tests\\TestData\\WellItCouldWork"));
        }   

        [Test]
        public void ShouldTellMeTheExternalDependenciesAProjectReferences()
        {
            Assert.That(project.HasAReferenceCalled("nunit.framework"));
        }         
        
        [Test]
        public void ShouldTellMeAboutTheClassesOfAProject()
        {
            Assert.That(project.HasAClassCalled("ClassInfo.cs"));
        }        
        

    }
}
    