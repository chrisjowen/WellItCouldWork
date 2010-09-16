using System.CodeDom.Compiler;
using System.Linq;
using Microsoft.CSharp;

namespace WellItCouldWork.BuildCreation
{
    public class BuildFilesCompiler : ICompileBuildFiles
    {
        public CompilationResult Compile(BuildFiles buildFiles)
        {
            var codeDomProvider = new CSharpCodeProvider();
            var options = new CompilerParameters();

            var references = buildFiles.References
                .Select(reference => reference.Path)
                .ToArray();

            options.ReferencedAssemblies.AddRange(references);

            var fileNames = buildFiles.AllClasses.Select(c => c.FullPath).ToArray();
            var result = codeDomProvider.CompileAssemblyFromFile(options, fileNames);

            var errors = result.Errors.Cast<object>().Select(error => error.ToString());
            return new CompilationResult(errors, result.PathToAssembly);
        }
    }
}