using System.Collections.Generic;
using System.Linq;

namespace WellItCouldWork.Tests.TestSyntaxHelpers
{
    public static class ExternalDependenciesExtentions
    {
        public static bool HasADependencyCalled(this IList<ExternalReference> dependencies, string assemblyName)
        {
            return dependencies.Any(d => d.AssemblyName == assemblyName);
        }
    }
}