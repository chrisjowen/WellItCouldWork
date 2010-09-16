using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WellItCouldWork.Investigation
{
    public class SolutionFile : ISolutionFile
    {
        private readonly IList<IProjectFile> projects = new List<IProjectFile>();
        private readonly string content = string.Empty;

        public string Name { get; private set; }
        public string Path { get; private set; }

        public SolutionFile(string filePath)
        {
            var file = new FileInfo(filePath);
            content = File.ReadAllText(filePath);
            Path = file.DirectoryName;
            Name = file.Name;
            ResolveProjectFiles();
        }
        private void ResolveProjectFiles()
        {
            var matches = new Regex("[.A-Za-z0-9\\\\]*.csproj").Matches(content);
            foreach (var match in matches.Cast<Match>())
                projects.Add(ProjectFile.FromFile(string.Format("{0}\\{1}", Path, match.Value)));
        }

        public IList<IProjectFile> Projects
        {
            get { return new List<IProjectFile>(projects); }
        }

        public IList<Reference> AllReferences
        {
            get { return Projects.SelectMany(p => p.References).ToList(); }
        }

        public Class FindClassByType(TypeInfo type)
        {
            return AllClasses.FirstOrDefault(c => c.ClassName == type.Name + ".cs");
        }
        
        private IEnumerable<Class> AllClasses
        {
            get { return Projects.SelectMany(p => p.Classes); }
        }
    }
}