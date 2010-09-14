using System.Linq;
using WellItCouldWork.Investigation;

namespace WellItCouldWork.Tests.TestSyntaxHelpers
{
    public static class ProjectExt
    {
        public static bool HasAReferenceCalled(this Project project, string referenceAssemblyName)
        {
            return project.References.Any(reference => reference.AssemblyName == referenceAssemblyName);
        }

        public static bool HasAClassCalled(this Project project, string className)
        {
            return project.Classes.Any(reference => reference.ClassName == className);
        }
    }
}
