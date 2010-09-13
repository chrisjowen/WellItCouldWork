using System.Collections.Generic;
using System.Text;

namespace WellItCouldWork
{
    internal class BuildFile
    {
        private readonly IList<ClassInfo> classes = new List<ClassInfo>();
        private readonly IList<ExternalReference> references = new List<ExternalReference>();

        public BuildFile(IList<ClassInfo> classes, IList<ExternalReference> externalReferences)
        {
            this.classes = classes;
            references = externalReferences;
        }

        public static BuildFile Empty
        {
            get { return new BuildFile(null, null); }
        }

        public string GenerateOutput()
        {
            var projectOutput = new StringBuilder("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            projectOutput.AppendLine("<Project ToolsVersion=\"4.0\" DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">");
            projectOutput.AppendLine(GetReferences());
            projectOutput.AppendLine(GetClasses());
            projectOutput.AppendLine("</Project>");
            return projectOutput.ToString();
        }

        private string GetClasses()
        {
            var sb = new StringBuilder("<ItemGroup>");
            foreach (var classInfo in classes)
                sb.Append(classInfo.GetBuildText());
            sb.Append("</ItemGroup>");
            return sb.ToString();
        }


        private string GetReferences()
        {
            var sb = new StringBuilder("<ItemGroup>");
            foreach (var reference in references)
                sb.Append(reference.GetBuildText());
            sb.Append("</ItemGroup>");
            return sb.ToString();
        }
    }
}