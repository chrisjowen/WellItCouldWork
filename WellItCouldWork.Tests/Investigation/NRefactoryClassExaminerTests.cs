using NUnit.Framework;
using WellItCouldWork.Investigation;
using WellItCouldWork.Tests.TestSyntaxHelpers;

namespace WellItCouldWork.Tests.Investigation
{
    [TestFixture]
    public class NRefactoryClassExaminerTests
    {
        private readonly IExamineSourceFiles sourceExaminer = new NRefactorySourceExaminer();
        
        [Test]
        public void ShouldTellMeTheInfoAboutASuperClassOfAGivenClass()
        {
            const string sourceCode = @"public class Foo : Bar {  }";
            var types = sourceExaminer.ExamineTypes(sourceCode);
            Assert.That(types.Count, Is.EqualTo(2));
            Assert.That(types.ContainsWithName("Foo"));
            Assert.That(types.ContainsWithName("Bar"));
        }

        [Test]
        public void ShouldTellMeTheNameOfAnyInterfacesFoundOnAGivenClass()
        {
            const string sourceCode = @"public class Foo : IBar {  }";
            var types = sourceExaminer.ExamineTypes(sourceCode);
            Assert.That(types.ContainsWithName("Foo"));
            Assert.That(types.ContainsWithName("IBar"));
        }

        [Test]
        public void ShouldTellMeAboutTheDependenciesAtFieldLevel()
        {
            const string sourceCode = @"public class Foo { Bar b = new Bar(); }";
            var types = sourceExaminer.ExamineTypes(sourceCode);
            Assert.That(types.Count, Is.EqualTo(2));
            Assert.That(types.ContainsWithName("Foo"));
            Assert.That(types.ContainsWithName("Bar"));
        }

        [Test]
        public void ShouldTellMeAboutTheDependenciesAtLocalVarLevel()
        {
            const string sourceCode = @"public class Foo { public void FooMethod() { Bar b = new Bar(); } }";
            var types = sourceExaminer.ExamineTypes(sourceCode);
            Assert.That(types.Count, Is.EqualTo(3));
            Assert.That(types.ContainsWithName("Foo"));
            Assert.That(types.ContainsWithName("Bar"));
        }
            
        [Test]
        public void ShouldTellMeTheNameOfAnyDepndenciesWhenCasting()
        {
            const string sourceCode = @"public class Foo { public void FooMethod() { return (Bar)""abc""; } }";
            var types = sourceExaminer.ExamineTypes(sourceCode);
            Assert.That(types.ContainsWithName("Bar"));
        }

        [Test]
        public void ShouldTellMeTheNameOfAnyDepndenciesUsedInGenericObjectConstruction()
        {
            const string sourceCode = @"public class Foo { public void FooMethod() { return new List<Bar>(); } }";
            var types = sourceExaminer.ExamineTypes(sourceCode);
            Assert.That(types.ContainsWithName("Bar"));
        }        
        
        [Test]
        public void ShouldTellMeTheNameOfAnyDepndenciesUsedInGenericConstructor()
        {
            const string sourceCode = @"public class Foo<Bar> {  } }";
            var types = sourceExaminer.ExamineTypes(sourceCode);
            Assert.That(types.ContainsWithName("Bar"));
        }
    }



}
