﻿using System.Collections.Generic;
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
            var buildFileOutput = BuildFile.Default.GenerateOutput();
            Assert.That(buildFileOutput.Contains("<?xml version=\"1.0\" encoding=\"utf-8\"?>"));
            Assert.That(buildFileOutput.Contains("<Project ToolsVersion=\"4.0\" DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">"));
            Assert.That(buildFileOutput.Contains("</Project>"));
        }

        [Test]
        public void ShouldCreateReferences()
        {
            IList<Reference> references = new List<Reference> { new Reference("System.Xml") };
            var buildFileOutput = new BuildFile(new List<Class>(), references).GenerateOutput();
            Assert.That(buildFileOutput.Contains("<ItemGroup>"));
            Assert.That(buildFileOutput.Contains("<Reference Include=\"System.Xml\"></Reference>"));
            Assert.That(buildFileOutput.Contains("</ItemGroup>"));
        }

        [Test]
        public void ShouldCreateABuildFileContainingAGivenClass()
        {
            IList<Class> classes = new List<Class> { fooClass };
            var buildFileOutput = new BuildFile(classes, new List<Reference>()).GenerateOutput();
            Assert.That(buildFileOutput.Contains(string.Format("<Compile Include=\"{0}\" />", fooClass.ClassName)));

        }
    }    
}
