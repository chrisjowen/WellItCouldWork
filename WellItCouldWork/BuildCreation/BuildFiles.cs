using System.Collections.Generic;

namespace WellItCouldWork.BuildCreation
{
    public class BuildFiles
    {
        public BuildFiles(Class target, IList<Class> dependentClasses, IList<Reference> references)
        {
            Target = target;
            DependentClasses = dependentClasses;
            References = references;
        }

        public Class Target { get; set; }
        public IList<Class> DependentClasses { get; set; }
        public IList<Reference> References { get; set; }

        public string GenerateBuildFile()
        {
            return BuildFileGenerator.GenerateFrom(DependentClasses, References);
        }
    }
}