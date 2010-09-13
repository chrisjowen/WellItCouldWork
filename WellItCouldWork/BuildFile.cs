using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WellItCouldWork
{
    public class BuildFile
    {
        private readonly IList<ClassInfo> classInfo = new List<ClassInfo>();
        private  IList<ExternalReference> references = new List<ExternalReference>();

        public BuildFile(IList<ClassInfo> classInfo, IList<ExternalReference> externalReferences)
        {
            this.classInfo = classInfo;
            references = externalReferences;
        }

        public static BuildFile Empty
        {
            get { return new BuildFile(null, null); }
        }

        public string GenerateOutput()
        {
            var projectOutput = new StringBuilder();
            projectOutput.Append(GetProjectInfo());
            return GetReferences();
        }

        private string GetProjectInfo()
        {
            return string.Empty;
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