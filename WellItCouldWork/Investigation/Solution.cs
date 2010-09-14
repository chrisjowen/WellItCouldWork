using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WellItCouldWork.Investigation
{
    public class Solution : ISolution
    {
        private readonly IList<IProject> projects = new List<IProject>();
        private readonly string content = string.Empty;

        public string Name { get; private set; }
        public string Path { get; private set; }

        public Solution(string filePath)
        {
            var file = new FileInfo(filePath);
            content = File.ReadAllText(filePath);
            Path = file.DirectoryName;
            Name = file.Name;
            InitializeProjects();
        }
        private void InitializeProjects()
        {
            var matches = new Regex("[.A-Za-z0-9\\\\]*.csproj").Matches(content);
            foreach (var match in matches.Cast<Match>())
                projects.Add(Project.FromFile(string.Format("{0}\\{1}", Path, match.Value)));
        }

        public IList<IProject> Projects
        {
            get { return new List<IProject>(projects); }
        }


        private IEnumerable<Class> AllClasses
        {
            get { return Projects.SelectMany(p => p.Classes); }
        }

        public Class FindClassByExample(Class @class)
        {
            return AllClasses.FirstOrDefault(c => c.ClassName == @class.ClassName);
        }
    }
}