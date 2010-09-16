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
            var fileName = new FileInfo(testFileDir).Name;
            fileName = fileName.Substring(0, fileName.Length - 3);

            var monkey = new Programmer(new NRefactorySourceExaminer(), solution, new SourceFromFileRepository());
            var buildFile = monkey.BuildFilesRequired(fileName);

            Console.WriteLine(buildFile.GenerateBuildFile());
            Console.ReadLine();

        }
    }
}
