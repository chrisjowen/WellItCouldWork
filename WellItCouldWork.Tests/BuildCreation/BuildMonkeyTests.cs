using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using WellItCouldWork.BuildCreation;
using WellItCouldWork.Investigation;

namespace WellItCouldWork.Tests.BuildCreation
{
    [TestFixture]
    public class BuildMonkeyTests
    {
        private IExamineSourceFiles examiner;
        private ISolutionFile solutionFile;
        private IGetSourceCode sourceCodeRepo;

        [SetUp]
        public void BeforeEachTest()
        {
            examiner = MockRepository.GenerateStub<IExamineSourceFiles>();
            solutionFile = MockRepository.GenerateStub<ISolutionFile>();
            sourceCodeRepo = MockRepository.GenerateStub<IGetSourceCode>();
        }

        [Test]
        public void ShouldRetrieveClassDependenciesFromExaminer()
        {
            const string source = @"public class Foo() {}";

            var fooClass = new Class("Foo");
            sourceCodeRepo.Stub(sr => sr.SourceFor(fooClass)).Return(source);

            new Programmer(examiner, solutionFile, sourceCodeRepo).BuildFilesRequired(fooClass);
            examiner.AssertWasCalled(e => e.ExamineTypes((source)));
        }        
        
        [Test]
        public void ShouldNotAddDependenciesToBuildFileIfNotInSolution()
        {
            examiner.Stub(e => e.ExamineTypes(Arg<string>.Is.Anything)).Return(new List<TypeInfo> { "Foo" });
            solutionFile.Stub(s => s.FindClassByType(Arg<TypeInfo>.Is.Anything)).Return(new Class("stub"));
            var buildFile = new Programmer(examiner, solutionFile, sourceCodeRepo).BuildFilesRequired(string.Empty);
            Assert.That(!buildFile.GenerateBuildFile().Contains("Foo.cs"), "Foo.cs should not be found in the solution");
        }

        [Test]
        public void ShouldAddDependencyIfInSolution()
        {
            var fooClass = new Class("Foo.cs");
            TypeInfo type = "Foo";
            examiner.Stub(e => e.ExamineTypes(Arg<string>.Is.Anything)).Return(new List<TypeInfo> { type });
            solutionFile.Stub(s => s.FindClassByType(type)).Return(fooClass);

            var buildFile = new Programmer(examiner, solutionFile, sourceCodeRepo).BuildFilesRequired(string.Empty);
            Assert.That(buildFile.GenerateBuildFile().Contains("Foo.cs"), "Foo.cs should be found in the solution");
        }
 
        [Test]
        public void ShouldAddAllReferencesFoundInSolution()
        {
            var references = new List<Reference>
            {
                new Reference("System.Web")
            };
            solutionFile.Stub(s => s.AllReferences).Return(references);

            var buildFile = new Programmer(examiner, solutionFile, sourceCodeRepo).BuildFilesRequired(string.Empty);
            Assert.That(buildFile.GenerateBuildFile().Contains("System.Web"), "System.Web reference should be found in the solution");
        }
    }    
    
}


