using System;
using NUnit.Framework;

namespace WellItCouldWork.Tests
{
    [TestFixture]
    public class BuildMonkeyTests
    {
        private readonly ClassInfo fooClassInfo = new ClassInfo("Foo");
        private readonly Action<BuildMonkey> withNoInstructions = m => { };

        [Test]
        public void ShouldCreateAnEmptyBuildFileWithDefaultValues()
        {
            var buildFile = BuildMonkey.MakeBuildFile();
            var buildFileOutput = buildFile.GenerateOutput();
            Assert.That(buildFileOutput.Contains("<?xml version=\"1.0\" encoding=\"utf-8\"?>"));
            Assert.That(buildFileOutput.Contains("<Project ToolsVersion=\"4.0\" DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">"));
            Assert.That(buildFileOutput.Contains("</Project>"));
        }

        [Test]
        public void ShouldCreateABuildFileContainingAGivenClass()
        {
            var buildFile = BuildMonkey.MakeBuildFile(m => m.WithAClass(fooClassInfo));
            var buildFileOutput = buildFile.GenerateOutput();
            Assert.That(buildFileOutput.Contains(string.Format("<Compile Include=\"{0}.cs\" />", fooClassInfo.ClassName)));
        }

        [Test]
        public void EmptyBuildFileOutputHasStandardReferences()
        {
            var buildFileOutput = BuildMonkey.MakeBuildFile(withNoInstructions).GenerateOutput();
            Assert.That(buildFileOutput.Contains("<Reference Include=\"System\"></Reference>"));
            Assert.That(buildFileOutput.Contains("<Reference Include=\"System.Core\"></Reference>"));
            Assert.That(buildFileOutput.Contains("<Reference Include=\"System.Data.DataSetExtensions\"></Reference>"));
            Assert.That(buildFileOutput.Contains("<Reference Include=\"System.Data\"></Reference>"));
            Assert.That(buildFileOutput.Contains("<Reference Include=\"System.Xml\"></Reference>"));
        }
    }    
    

}
