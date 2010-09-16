using System.Collections.Generic;
using System.Text;

namespace WellItCouldWork.BuildCreation
{
    public class BuildFileGenerator
    {
        public static string GenerateFrom(IList<Class> classes, IList<Reference> references)
        {
            var projectOutput = new StringBuilder("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            projectOutput.AppendLine("<Project ToolsVersion=\"4.0\" DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">");
            projectOutput.AppendLine(GenerateReferencesSection(references));
            projectOutput.AppendLine(GenerateClasses(classes));
            projectOutput.AppendLine("</Project>");
            return projectOutput.ToString();
        }

        private static string GenerateClasses(IEnumerable<Class> classes)
        {
            var sb = new StringBuilder("<ItemGroup>");
            foreach (var classInfo in classes)
                sb.Append(string.Format("<Compile Include=\"{0}\" />", classInfo.ClassName));
            sb.Append("</ItemGroup>");
            return sb.ToString();
        }

        private static string GenerateReferencesSection(IEnumerable<Reference> references)
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