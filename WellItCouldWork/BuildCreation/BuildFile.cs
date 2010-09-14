using System.Collections.Generic;
using System.Text;

namespace WellItCouldWork.BuildCreation
{
    public class BuildFile
    {
        private readonly IList<Class> classes = new List<Class>();
        private readonly IList<Reference> references = new List<Reference>();

        public BuildFile(IList<Class> classes, IList<Reference> externalReferences)
        {
            this.classes = classes;
            references = externalReferences;
        }

        public static BuildFile Default
        {
            get { return new BuildFile(new List<Class>(), new List<Reference>()); }
        }

        public string GenerateOutput()
        {
            var projectOutput = new StringBuilder("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            projectOutput.AppendLine("<Project ToolsVersion=\"4.0\" DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">");
            projectOutput.AppendLine(GenerateReferencesSection());
            projectOutput.AppendLine(GenerateClasses());
            projectOutput.AppendLine("</Project>");
            return projectOutput.ToString();
        }

        private string GenerateClasses()
        {
            var sb = new StringBuilder("<ItemGroup>");
            foreach (var classInfo in classes)
                sb.Append(string.Format("<Compile Include=\"{0}\" />", classInfo.ClassName));
            sb.Append("</ItemGroup>");
            return sb.ToString();
        }


        private string GenerateReferencesSection()
        {
            var sb = new StringBuilder("<ItemGroup>");
            foreach (var reference in references)
            {
                var referenceTag = new StringBuilder(string.Format("<Reference Include=\"{0}\">", reference.AssemblyName));
                if (!string.IsNullOrEmpty(reference.Path))
                    referenceTag.AppendFormat("<HintPath>{0}</HintPath>", reference.Path);
                referenceTag.Append("</Reference>");
                sb.Append(referenceTag.ToString());
            }
            sb.Append("</ItemGroup>");
            return sb.ToString();
        }
    }
}