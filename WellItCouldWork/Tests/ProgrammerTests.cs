using System.Linq;
using NUnit.Framework;

namespace WellItCouldWork.Tests
{
    [TestFixture]
    public class ProgrammerTests
    {
        private const string WipReason = "Not implemented yet WIP";

        [Test]
        public void ShouldTellMeThatTheClassNameOnAnEmptyClass()
        {
            var programmer = new Programmer();
            const string sourceCode = @"public class Empty {}";
            Assert.That(programmer.ExamineThisCode(sourceCode).First().ClassName, Is.EqualTo("Empty"));
        }

        [Test]
        public void ShouldTellMeThatTheClassNameOnAClassWithACtr()
        {
            var programmer = new Programmer();
            const string sourceCode = @"public class WithCtr { public WithCtr() {} }";
            Assert.That(programmer.ExamineThisCode(sourceCode).First().ClassName, Is.EqualTo("WithCtr"));
        }

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
            var programmer = new Programmer();
            const string sourceCode = @"public class Foo { Bar b = new Bar(); }";
            var classInfo = programmer.ExamineThisCode(sourceCode).First();

            Assert.That(classInfo.DependenendClasses.Count, Is.EqualTo(1));
            Assert.That(classInfo.DependenendClasses.First().ClassName, Is.EqualTo("Bar"));
        }

        [Test]
        public void ShouldTellMeAboutTheDependenciesAtLocalVarLevel()
        {
            var programmer = new Programmer();
            const string sourceCode = @"public class Foo { public void Foos() { Bar b = new Bar(); } }";
            var classInfo = programmer.ExamineThisCode(sourceCode).First();

            Assert.That(classInfo.DependenendClasses.Count, Is.EqualTo(1));
            Assert.That(classInfo.DependenendClasses.First().ClassName, Is.EqualTo("Bar"));
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
