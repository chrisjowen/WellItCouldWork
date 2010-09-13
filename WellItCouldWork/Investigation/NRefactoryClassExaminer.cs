using System.Collections.Generic;
using System.IO;
using System.Linq;
using ICSharpCode.NRefactory;
using ICSharpCode.NRefactory.Ast;

namespace WellItCouldWork.Investigation
{
    internal class NRefactoryClassExaminer : IExamineClassFiles
    {
        public IList<ClassInfo> Examine(string code)
        {
            var result =  GetCompilationResult(code);
            var flattenedTree = result.Flatten();
            var typeDeclerations = flattenedTree.OfType<TypeDeclaration>();
            return typeDeclerations.Select(ClassInfoFrom).ToList();
        }

        private static CompilationUnit GetCompilationResult(string sourceCode)
        {
            using (var parser = ParserFactory.CreateParser(SupportedLanguage.CSharp, new StringReader(sourceCode)))
            {
                parser.Parse();
                var result = parser.CompilationUnit;
                return result;
            }
        }

        private static ClassInfo ClassInfoFrom(TypeDeclaration type)
        {
            var classInfo = new ClassInfo(type.Name);
            foreach (var dependentType in type.Flatten().OfType<ObjectCreateExpression>())
                classInfo.AddDependentClass(new ClassInfo(dependentType.CreateType.Type));
            return classInfo;
        }
    }
}