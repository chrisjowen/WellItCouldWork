using System.Collections.Generic;
using WellItCouldWork.Investigation;

namespace WellItCouldWork.BuildCreation
{
    public class BuildMonkey 
    {
        private readonly IExamineClassFiles classExaminer;
        private readonly ISolution solution;
        private IList<Class> classDependencies = new List<Class>();
        private readonly IList<Reference> references = new List<Reference>();

        public BuildMonkey(IExamineClassFiles classExaminer, ISolution solution)
        {
            this.classExaminer = classExaminer;
            this.solution = solution;
        }

        public BuildFile MakeBuildFileFor(string source)
        {
            classDependencies = GetInternalClasses(classExaminer.ExamineClassDependencies(source));
            WithStandardReferences();
            return CreateBuildFile();
        }

        private IList<Class> GetInternalClasses(IEnumerable<Class> dependencies)
        {
            IList<Class> internalClasses = new List<Class>();
            if (dependencies == null) return internalClasses;

            foreach (var dependency in dependencies)
            {
                var solutionClass = solution.FindClassByExample(dependency);
                if (solutionClass != null) internalClasses.Add(solutionClass);
            }
            return internalClasses;
        }

        private void WithStandardReferences()
        {
            references.Add(new Reference("System"));
            references.Add(new Reference("System.Core"));
            references.Add(new Reference("System.Data.DataSetExtensions"));
            references.Add(new Reference("System.Data"));
            references.Add(new Reference("System.Xml"));
        }

        private BuildFile CreateBuildFile()
        {
            return new BuildFile(classDependencies, references);
        }

    }
}
