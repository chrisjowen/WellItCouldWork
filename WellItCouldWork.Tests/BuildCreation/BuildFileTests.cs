using System.Collections.Generic;
using NUnit.Framework;
using WellItCouldWork.BuildCreation;

namespace WellItCouldWork.Tests.BuildCreation
{
    [TestFixture]
    public class BuildFileTests
    {
        private readonly Class fooClass = new Class("Foo.cs");

        [Test]
        public void EmptyBuildFileOutputHasDefaultProjectInfo()
        {
            var buildFileOutput = BuildFileGenerator.GenerateFrom(new List<Class>(), new List<Reference>());
            Assert.That(buildFileOutput.Contains("<?xml version=\"1.0\" encoding=\"utf-8\"?>"));
            Assert.That(buildFileOutput.Contains("<Project ToolsVersion=\"4.0\" DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">"));
            Assert.That(buildFileOutput.Contains("</Project>"));
        }

        [Test]
        public void ShouldCreateReferences()
        {
            IList<Reference> references = new List<Reference> { new Reference("System.Xml") };
            var buildFileOutput = BuildFileGenerator.GenerateFrom(new List<Class>(), references);
            Assert.That(buildFileOutput.Contains("<ItemGroup>"));
            Assert.That(buildFileOutput.Contains("<Reference Include=\"System.Xml\"></Reference>"));
            Assert.That(buildFileOutput.Contains("</ItemGroup>"));
        }

        [Test]
        public void ShouldCreateABuildFileContainingAGivenClass()
        {
            IList<Class> classes = new List<Class> { fooClass };
            var buildFileOutput = BuildFileGenerator.GenerateFrom(classes, new List<Reference>());
            Assert.That(buildFileOutput.Contains(string.Format("<Compile Include=\"{0}\" />", fooClass.ClassName)));

        }
    }    
}
