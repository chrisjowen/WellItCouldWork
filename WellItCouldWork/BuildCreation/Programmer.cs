using System.Collections.Generic;
using System.Linq;
using WellItCouldWork.Investigation;

namespace WellItCouldWork.BuildCreation
{
    public class Programmer 
    {
        private readonly IExamineSourceFiles sourceExaminer;
        private readonly ISolutionFile solutionFile;
        private readonly IGetSourceCode sourceCodeRepo;
        private BuildFiles buildFiles;

        public Programmer(IExamineSourceFiles sourceExaminer, ISolutionFile solutionFile, IGetSourceCode sourceCodeRepo)
        {
            this.sourceExaminer = sourceExaminer;
            this.solutionFile = solutionFile;
            this.sourceCodeRepo = sourceCodeRepo;
        }

        public BuildFiles BuildFilesRequired(TypeInfo type)
        {
            return BuildFilesRequired(solutionFile.FindClassByType(type));
        }

        public BuildFiles BuildFilesRequired(Class @class)
        {
            var solutionsReferences = solutionFile.AllReferences ?? new List<Reference>();
            buildFiles =  new BuildFiles(@class, ResolveClassesRequiredFor(@class), solutionsReferences);
            return buildFiles;
        }

        private IList<Class> ResolveClassesRequiredFor(Class @class)
        {
            IList<Class> classDependencies = new List<Class>();
            var source = sourceCodeRepo.SourceFor(@class);
            var typesFoundInFile = sourceExaminer.ExamineTypes(source);
            if (typesFoundInFile!=null)
                classDependencies = MatchSolutionClasses(typesFoundInFile);

            return classDependencies;
        }

        private IList<Class> MatchSolutionClasses(IEnumerable<TypeInfo> types)
        {
            return types.Select(t => solutionFile.FindClassByType(t)).ToList();
        }

        //private void WithStandardReferences()
        //{
        //    references.Add(new Reference("System"));
        //    references.Add(new Reference("System.Core"));
        //    references.Add(new Reference("System.Data.DataSetExtensions"));
        //    references.Add(new Reference("System.Data"));
        //    references.Add(new Reference("System.Xml"));
        //}



    }
}
