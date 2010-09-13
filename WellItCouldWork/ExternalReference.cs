using System.Text;

namespace WellItCouldWork
{
    public class ExternalReference
    {
        public ExternalReference(string assemblyName, string path)
        {
            AssemblyName = assemblyName;
            Path = path;
        }

        public ExternalReference(string assemblyName)
            : this(assemblyName, string.Empty)
        {
        }
        public string AssemblyName { get; private set; }
        public string Path { get; private set; }

        public string GetBuildText()
        {
            var referenceTag = new StringBuilder(string.Format("<Reference Include=\"{0}\">", AssemblyName));
            if (!string.IsNullOrEmpty(Path))
                referenceTag.AppendFormat("<HintPath>{0}</HintPath>", Path);
            referenceTag.Append("</Reference>");
            return referenceTag.ToString();
        }
    }
}