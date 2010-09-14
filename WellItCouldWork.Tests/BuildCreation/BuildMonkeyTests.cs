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
        private IExamineClassFiles examiner;
        private ISolution solution;

        [SetUp]
        public void BeforeEachTest()
        {
            examiner = MockRepository.GenerateStub<IExamineClassFiles>();
            solution = MockRepository.GenerateStub<ISolution>();
        }

        [Test]
        public void ShouldRetrieveClassDependenciesFromExaminer()
        {
            const string source = @"public class Foo() {}";
            new BuildMonkey(examiner, solution).MakeBuildFileFor(source);
            examiner.AssertWasCalled(e => e.ExamineClassDependencies(source));
        }        
        
        [Test]
        public void ShouldNotAddDependenciesToBuildFileIfNotInSolution()
        {
            examiner.Stub(e => e.ExamineClassDependencies(Arg<string>.Is.Anything))
                    .Return(new List<Class> { new Class("Foo.cs") });

            var buildFile = new BuildMonkey(examiner, solution).MakeBuildFileFor(string.Empty);
            Assert.That(!buildFile.GenerateOutput().Contains("Foo.cs"), "Foo.cs should not be found in the solution");
        }

        [Test]
        public void ShouldAddDependencyIfInSolution()
        {
            var fooClass = new Class("Foo.cs");
            examiner.Stub(e => e.ExamineClassDependencies(Arg<string>.Is.Anything))
                    .Return(new List<Class> { fooClass });

            solution.Stub(s => s.FindClassByExample(fooClass)).Return(fooClass);

            var buildFile = new BuildMonkey(examiner, solution).MakeBuildFileFor(string.Empty);
            Assert.That(buildFile.GenerateOutput().Contains("Foo.cs"), "Foo.cs should be found in the solution");
        }
    }    
    
}


