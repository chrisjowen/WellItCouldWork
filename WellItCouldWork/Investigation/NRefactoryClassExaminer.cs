using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ICSharpCode.NRefactory;
using ICSharpCode.NRefactory.Ast;

namespace WellItCouldWork.Investigation
{
    public class NRefactoryClassExaminer : IExamineClassFiles
    {
        private static CompilationUnit GetCompilationResult(string sourceCode)
        {
            using (var parser = ParserFactory.CreateParser(SupportedLanguage.CSharp, new StringReader(sourceCode)))
            {
                parser.Parse();
                var result = parser.CompilationUnit;
                return result;
            }
        }

        private static IList<Class> ClassInfoFrom(TypeDeclaration type)
        {
            return type.Flatten().OfType<ObjectCreateExpression>()
                .Select(dependentType => new Class(dependentType.CreateType.Type))
                .ToList();
        }

        public IList<Reference> ExamineReferences(string code)
        {
            throw new NotImplementedException();
        }

        public IList<Class> ExamineClassDependencies(string code)
        {
            var result = GetCompilationResult(code);
            IEnumerable<INode> enumerable = result.Flatten();
            return enumerable.OfType<ObjectCreateExpression>()
                .Select(dependentType => new Class(dependentType.CreateType.Type + ".cs"))
                .ToList();
        }
    }
}