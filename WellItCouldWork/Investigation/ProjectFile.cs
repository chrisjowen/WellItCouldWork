using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace WellItCouldWork.Investigation
{
    public class ProjectFile : IProjectFile
    {
        public string ProjectLocation { get; private set; }
        public string ProjectName { get; private set; }
        public IList<Reference> References { get; private set; }
        public IList<Class> Classes { get; private set; }

        private ProjectFile(string projectName, string projectLoacation, IEnumerable<XElement> docElements)
        {
            ProjectLocation = projectLoacation;
            ProjectName = projectName;
            References = ReferencesFrom(docElements);
            Classes = ClassesFrom(docElements);
        }

        public static ProjectFile Load(string fileName)
        {
            var projectFile = new FileInfo(fileName);
            var projectDocument = XDocument.Load(projectFile.OpenRead());
            var root = projectDocument.Document;
            return new ProjectFile(projectFile.Name,  projectFile.DirectoryName, root.Descendants());
        }


        private IList<Reference> ReferencesFrom(IEnumerable<XElement> elements)
        {
            return elements
                .Where(el => el.Name.LocalName == "Reference")
                .Select(GetReferenceFor).ToList();
        }

        private List<Class> ClassesFrom(IEnumerable<XElement> elements)
        {
            return elements.Where(decendent => decendent.Name.LocalName == "Compile")
                .Select(el => string.Format("{0}//{1}", ProjectLocation, el.Attribute("Include").Value))
                .Select(Class.FromPath).ToList();
        }

        private Reference GetReferenceFor(XElement decendent)
        {

            var hintPath = decendent.Descendants()
                .Where(d => d.Name.LocalName == "HintPath")
                .Select(h => h.Value)
                .FirstOrDefault();

            if (!string.IsNullOrEmpty(hintPath))
            {
                var directory = new DirectoryInfo(ProjectLocation + "\\" + hintPath);
                return new Reference(directory.FullName);
            }
            return new Reference(decendent.Attribute("Include").Value);
        }

    }
}