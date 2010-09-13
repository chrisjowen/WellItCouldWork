using System;
using System.Collections.Generic;

namespace WellItCouldWork
{
    public class BuildMonkey
    {
        private readonly IList<ClassInfo> classDependencies = new List<ClassInfo>();
        private readonly IList<ExternalReference> references = new List<ExternalReference>();

        private BuildMonkey(){}

        public BuildMonkey And
        {
            get { return this; }
        }

        public static BuildFile MakeBuildFile(Action<BuildMonkey> instructions = null)
        {
            var buildMonkey = new BuildMonkey();
            buildMonkey.WithStandardReferences();
            if (instructions!=null) instructions.Invoke(buildMonkey);
            return buildMonkey.Build();
        }

        private void WithStandardReferences()
        {
            references.Add(new ExternalReference("System"));
            references.Add(new ExternalReference("System.Core"));
            references.Add(new ExternalReference("System.Data.DataSetExtensions"));
            references.Add(new ExternalReference("System.Data"));
            references.Add(new ExternalReference("System.Xml"));
        }

        private BuildFile Build()
        {
            return new BuildFile(classDependencies, references);
        }

        public BuildMonkey WithAClass(ClassInfo classInfo)
        {
            classDependencies.Add(classInfo);
            return this;
        }
    }
}
