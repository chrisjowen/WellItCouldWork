using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WellItCouldWork.BuildCreation;
using WellItCouldWork.Investigation;
using WellItCouldWork.TestRunner;

namespace WellItCouldWork.Runner
{
    class Program
    {
        private static string tempDllName;
        private static string solutionDir;
        private static string testFile;
        private static readonly string tempPath = string.Format("{0}//WellItCouldWork//", Path.GetTempPath());

        static void Main(string[] args)
        {
            if(args.Count() != 2) throw new ApplicationException("Solution and Test file required");

            solutionDir = args[0];
            testFile = args[1];

            BeginTestExecution(solutionDir, testFile);

            var fileInfo = new FileInfo(testFile);
            if (fileInfo.Directory == null)
                throw new IOException("File Path has no directory to watch");

            var incoming = new FileSystemWatcher
                               {
                                   NotifyFilter = NotifyFilters.Size,
                                   Path = fileInfo.Directory.FullName,
                                   Filter = fileInfo.Name
                               };
            incoming.Changed += FsWatcherChanged;
            incoming.EnableRaisingEvents = true;

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Started watching file.");
            Console.WriteLine("Press \'q\' to quit.");
            while (Console.Read() != 'q') {}

        }

        static void FsWatcherChanged(object sender, FileSystemEventArgs e)
        {
            BeginTestExecution(solutionDir, testFile);
        }

        private static void BeginTestExecution(string solutionDir, string testFileDir)
        {
            ClearTempPath();
  
            var type = GetLookupType(testFileDir);

            var solution = SolutionFile.Load(solutionDir);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Determening files To compile");
            Console.WriteLine("-------------------------------");

            var buildFiles = BuildMonkey.Using(new NRefactorySourceExaminer(), solution, new SourceFromFileRepository())
                .WhatFilesAreRequiredToBuild(type);

            Console.WriteLine("Found classes:");
            foreach(var dependentClass in buildFiles.DependentClasses)
                Console.WriteLine(" - " + dependentClass.ClassName);


            Console.WriteLine("Found references:");
            CopyReferencesToTempDir(buildFiles.References.Where(r => r.IsExternalAssembily));

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Compiling files");
            Console.WriteLine("-------------------------------");

            var buildFilesCompiler = new BuildFilesCompiler();
            var result = buildFilesCompiler.Compile(buildFiles);
            ProcessResult(result);
        }

        private static void ClearTempPath()
        {
            if(Directory.Exists(tempPath))
                Directory.Delete(tempPath, true);
            Directory.CreateDirectory(tempPath);
        }

        private static void CopyReferencesToTempDir(IEnumerable<Reference> references)
        {
            foreach (var reference in references)
            {
                var copyToPath = string.Format("{0}{1}", tempPath, reference.Filename);
                Console.WriteLine(string.Format(" - Copying '{0}' to '{1}'", reference.FullPath, copyToPath));
                File.Copy(reference.FullPath, copyToPath, true);
            }
        }

        private static void ProcessResult(CompilationResult result)
        {
            if (result.HasErrors)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                ProcesErrors(result);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                ProcessSucessfullBuild(result);
            }
        }

        private static void ProcessSucessfullBuild(CompilationResult result)
        {
            Console.WriteLine("Temporary assembly created at: " + result.AssemblyLocation);
            tempDllName = string.Format("{0}{1}", tempPath, "tmp.dll");
            File.Copy(result.AssemblyLocation, string.Format(tempDllName, tempPath));

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Running Tests");
            Console.WriteLine("-------------------------------");

            RunTestsFor(tempDllName);
        }

        private static void RunTestsFor(string tempDllName)
        {
            IRunUnitTests testRunner = new NUnitConsoleRunner(tempDllName);
            Console.WriteLine(testRunner.RunAllTests());
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
