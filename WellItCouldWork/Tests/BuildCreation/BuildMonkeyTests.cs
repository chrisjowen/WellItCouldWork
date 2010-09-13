using NUnit.Framework;
using WellItCouldWork.BuildCreation;

namespace WellItCouldWork.Tests.BuildCreation
{
    [TestFixture]
    public class BuildMonkeyTests
    {
        private readonly ClassInfo fooClassInfo = new ClassInfo("Foo");

        [Test]
        public void EmptyBuildFileOutputHasDefaultProjectInfo()
        {
            var buildFileOutput = BuildMonkey.MakeBuildFile();
            Assert.That(buildFileOutput.Contains("<?xml version=\"1.0\" encoding=\"utf-8\"?>"));
            Assert.That(buildFileOutput.Contains("<Project ToolsVersion=\"4.0\" DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">"));
            Assert.That(buildFileOutput.Contains("</Project>"));
        }

        [Test]
        public void EmptyBuildFileOutputHasStandardReferences()
        {
            var buildFileOutput = BuildMonkey.MakeBuildFile();
            Assert.That(buildFileOutput.Contains("<ItemGroup>"));
            Assert.That(buildFileOutput.Contains("<Reference Include=\"System\"></Reference>"));
            Assert.That(buildFileOutput.Contains("<Reference Include=\"System\"></Reference>"));
            Assert.That(buildFileOutput.Contains("<Reference Include=\"System.Core\"></Reference>"));
            Assert.That(buildFileOutput.Contains("<Reference Include=\"System.Data.DataSetExtensions\"></Reference>"));
            Assert.That(buildFileOutput.Contains("<Reference Include=\"System.Data\"></Reference>"));
            Assert.That(buildFileOutput.Contains("<Reference Include=\"System.Xml\"></Reference>"));
            Assert.That(buildFileOutput.Contains("</ItemGroup>"));
        }

        [Test]
        public void ShouldCreateABuildFileContainingAGivenClass()
        {
            var buildFileOutput = BuildMonkey.MakeBuildFile(m => m.WithAClass(fooClassInfo));
            Assert.That(buildFileOutput.Contains(string.Format("<Compile Include=\"{0}.cs\" />", fooClassInfo.ClassName)));

        }
    }    
}
