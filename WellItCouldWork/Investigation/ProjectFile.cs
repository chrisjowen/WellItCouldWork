using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace WellItCouldWork.Investigation
{
    public class ProjectFile : IProjectFile
    {
        private IEnumerable<XElement> decendents;
        public string ProjectLocation { get; private set; }
        public string ProjectName { get; private set; }
        public List<Reference> References { get; private set; }
        public IList<Class> Classes { get; private set; }

        private ProjectFile()
        {
            References = new List<Reference>();
        }

        public static ProjectFile FromFile(string projectFile)
        {
            var project = new ProjectFile();
            var projectDocument = XDocument.Load(projectFile);
            project.decendents = projectDocument.Document.Descendants();
            project.InitializeFrom(projectFile);
            return project;
        }

        private void InitializeFrom(string fileLocation)
        {
            var projectFile = new FileInfo(fileLocation);
            ProjectLocation = projectFile.DirectoryName;
            ProjectName = projectFile.Name;
            InitializeReferences();
            InitializeClasses();
        }

        private void InitializeReferences()
        {
            References = new List<Reference>();
            foreach (var decendent in decendents.Where(decendent => decendent.Name.LocalName == "Reference"))
            {
                References.Add(GetReferenceFor(decendent));
            }
        }

        private void InitializeClasses()
        {
            Classes = new List<Class>();

            foreach (var compilationDependency in decendents.Where(decendent => decendent.Name.LocalName == "Compile"))
            {
                var filePath = string.Format("{0}//{1}", ProjectLocation, compilationDependency.Attribute("Include").Value);
                Classes.Add(Class.FromPath(filePath));
            }
        }

        private Reference GetReferenceFor(XElement decendent)
        {
            if (!string.IsNullOrEmpty(decendent.Value))
            {
                var directory = new DirectoryInfo(ProjectLocation + "\\" + decendent.Value);
                return new Reference(directory.FullName);
            }
            return new Reference(decendent.Attribute("Include").Value);
        }

    }
}