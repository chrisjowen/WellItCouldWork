using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace WellItCouldWork.Investigation
{
    public class ProjectFile : IProjectFile
    {
        private XmlNode projectDocumentRoot;
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
            var projectDocument = new XmlDocument();
            projectDocument.Load(projectFile);
            project.projectDocumentRoot = projectDocument.DocumentElement;
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
            foreach (XmlNode referenceNode in projectDocumentRoot.ChildNodes[3].ChildNodes) //XPath is so anoying, come back
            {
                if (referenceNode.Attributes == null) continue;
                if (!referenceNode.HasChildNodes) continue;

                var dependencyName = referenceNode.Attributes["Include"].Value;
                var path = referenceNode.ChildNodes[0].InnerText;
                References.Add(new Reference(dependencyName, path));
            }
        }        
        
        private void InitializeClasses()
        {
            Classes = new List<Class>();
            foreach (XmlNode referenceNode in projectDocumentRoot.ChildNodes[4].ChildNodes) //XPath is so anoying, come back
            {
                if (referenceNode.Attributes == null) continue;
                var dependencyName = referenceNode.Attributes["Include"].Value;
                Classes.Add(Class.FromPath(string.Format("{0}//{1}",ProjectLocation,  dependencyName)));
            }
        }

 

    }
}