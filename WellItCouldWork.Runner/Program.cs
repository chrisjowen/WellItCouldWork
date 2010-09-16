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


            var solution = new SolutionFile(solutionDir);
            string fileName = GetFileName(testFileDir);

            Console.WriteLine("Determening files To compile");
            Console.WriteLine("-------------------------------");

            var buildFiles = BuildMonkey.Using(new NRefactorySourceExaminer(), solution, new SourceFromFileRepository())
                                        .WhatFilesAreRequiredToBuild(fileName);

            Console.WriteLine("Found files:");

            foreach(var dependentClass in buildFiles.DependentClasses)
                Console.WriteLine("\t " + dependentClass.ClassName);


            Console.WriteLine("-------------------------------");
            Console.WriteLine("Compiling files");
            Console.WriteLine("-------------------------------");

            var buildFilesCompiler = new BuildFilesCompiler();
            var result = buildFilesCompiler.Compile(buildFiles);

            if (result.HasErrors)
            {
                Console.WriteLine("Errors Compiling files");
                foreach (var error in result.Errors)
                {
                    Console.WriteLine("\t" + error);
                }
            }
            else
            {
                Console.WriteLine("Temporary assembly created at: " + result.AssemblyLocation);
            }

           // Console.WriteLine(buildFile.GenerateBuildFile());
            Console.ReadLine();

        }

        private static string GetFileName(string testFileDir)
        {
            var fileName = new FileInfo(testFileDir).Name;
            fileName = fileName.Substring(0, fileName.Length - 3);
            return fileName;
        }
    }
}
