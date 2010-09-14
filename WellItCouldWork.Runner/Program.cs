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
            var solution = new Solution(solutionDir);

            var fileName = new FileInfo(testFileDir);

            var testClass = solution.FindClassByExample(fileName.Name);
            var buildFile = new BuildMonkey(new NRefactoryClassExaminer(), solution)
                .MakeBuildFileFor(testClass.GetSource());

            Console.WriteLine(buildFile.GenerateOutput());
            Console.ReadLine();

        }
    }
}
