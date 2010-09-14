using System.Text;

namespace WellItCouldWork
{
    public class Reference
    {
        public Reference(string assemblyName, string path)
        {
            AssemblyName = assemblyName;
            Path = path;
        }

        public Reference(string assemblyName)
            : this(assemblyName, string.Empty)
        {
        }
        public string AssemblyName { get; private set; }
        public string Path { get; private set; }
    }
}