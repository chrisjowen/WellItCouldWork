using System.Linq;
using NUnit.Framework;
using WellItCouldWork.Investigation;

namespace WellItCouldWork.Tests.Investigation
{
    [TestFixture]
    public class NRefactoryClassExaminerTests
    {
        private const string WipReason = "Not implemented yet WIP";
        private readonly IExamineClassFiles classExaminer = new NRefactoryClassExaminer();
        
        [Test]
        public void ShouldTellMeTheInfoAboutASuperClassOfAGivenClass()
        {
          Assert.True(false, WipReason);
        }

        [Test]
        public void ShouldTellMeTheNameOfAnyInterfacesFoundOnAGivenClass()
        {
            Assert.True(false, WipReason);
        }

        [Test]
        public void ShouldTellMeAboutTheDependenciesAtFieldLevel()
        {
            const string sourceCode = @"public class Foo { Bar b = new Bar(); }";
            var classInfo = classExaminer.ExamineClassDependencies(sourceCode);
            Assert.That(classInfo.Count, Is.EqualTo(1));
            Assert.That(classInfo.First().ClassName, Is.EqualTo("Bar.cs"));
        }

        [Test]
        public void ShouldTellMeAboutTheDependenciesAtLocalVarLevel()
        {
            const string sourceCode = @"public class Foo { public void Foos() { Bar b = new Bar(); } }";
            var classInfo = classExaminer.ExamineClassDependencies(sourceCode);

            Assert.That(classInfo.Count, Is.EqualTo(1));
            Assert.That(classInfo.First().ClassName, Is.EqualTo("Bar.cs"));
        }

        [Test]
        public void ShouldTellMeTheNameOfAnyDepndenciesWhenCasting()
        {
            Assert.True(false, WipReason);
        }

        [Test]
        public void ShouldTellMeTheNameOfAnyDepndencies()
        {
            Assert.True(false, WipReason);
        }
    }



}
