using System;
using System.IO;
using System.Linq;
using WellItCouldWork.BuildCreation;
using WellItCouldWork.Investigation;

namespace WellItCouldWork.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Count() != 2) throw new ApplicationException("Solution and Test file required");

            var solutionDir = args[0];
            var testFileDir = args[1];
            var type = GetLookupType(testFileDir);

            var solution = SolutionFile.Load(solutionDir);

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Determening files To compile");
            Console.WriteLine("-------------------------------");

            var buildFiles = BuildMonkey.Using(new NRefactorySourceExaminer(), solution, new SourceFromFileRepository())
                                        .WhatFilesAreRequiredToBuild(type);

            foreach(var dependentClass in buildFiles.DependentClasses)
                Console.WriteLine(" - " + dependentClass.ClassName);


            Console.WriteLine("-------------------------------");
            Console.WriteLine("Compiling files");
            Console.WriteLine("-------------------------------");

            var buildFilesCompiler = new BuildFilesCompiler();
            var result = buildFilesCompiler.Compile(buildFiles);
            ProcessResult(result);
            Console.ReadLine();

        }

        private static void ProcessResult(CompilationResult result)
        {
            if (result.HasErrors)
            {
                ProcesErrors(result);
            }
            else
            {
                ProcessSucessfullBuild(result);
            }
        }

        private static void ProcessSucessfullBuild(CompilationResult result)
        {
            Console.WriteLine("Temporary assembly created at: " + result.AssemblyLocation);
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Running Tests");
            Console.WriteLine("-------------------------------");
        }

        private static void ProcesErrors(CompilationResult result)
        {
            Console.WriteLine("Errors Compiling files:");
            foreach (var error in result.Errors)
                Console.WriteLine("\t" + error);
        }

        private static TypeInfo GetLookupType(string testFileDir)
        {
            var fileName = new FileInfo(testFileDir).Name;
            fileName = fileName.Substring(0, fileName.Length - 3);
            return fileName;
        }
    }
}
