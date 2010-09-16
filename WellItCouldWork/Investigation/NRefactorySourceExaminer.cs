using System.Collections.Generic;
using System.IO;
using System.Linq;
using ICSharpCode.NRefactory;
using ICSharpCode.NRefactory.Ast;

namespace WellItCouldWork.Investigation
{
    public class NRefactorySourceExaminer : IExamineSourceFiles
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

        public IList<TypeInfo> ExamineTypes(string code)
        {
            var result = GetCompilationResult(code);
            var nodes = result.Flatten();

            var types = new List<TypeInfo>();

            foreach (var node in nodes)
            {
                if (node.IsA<ObjectCreateExpression>())
                {
                    var creationNode = (ObjectCreateExpression) node;
                    types.Add(new TypeInfo(creationNode.CreateType.Type));
                }
                if (node.IsA<TypeDeclaration>())
                {
                    var creationNode = (TypeDeclaration)node;
                    types.Add(new TypeInfo(creationNode.Name));
                }
                if (node.IsA<TypeReference>())
                {
                    var creationNode = (TypeReference)node;
                    types.Add(new TypeInfo(creationNode.Type));
                }                
                if (node.IsA<TemplateDefinition>())
                {
                    var creationNode = (TemplateDefinition)node;
                    types.Add(new TypeInfo(creationNode.Name));
                }
            }
            return types.Distinct(new TypeNameComparer()).ToList();
        }
    }
}