using System.Collections.Generic;

namespace WellItCouldWork
{
    public class ClassInfo
    {
        private readonly IList<ClassInfo> dependenendClasses = new List<ClassInfo>();
        public string ClassName { get; private set; }

        public ClassInfo(string className)
        {
            ClassName = className;
        }

        public IList<ClassInfo> DependenendClasses
        {
            get { return new List<ClassInfo>(dependenendClasses).AsReadOnly(); }
        }

        public void AddDependentClass(ClassInfo dependentClass)
        {
            dependenendClasses.Add(dependentClass);
        }

        public string GetBuildText()
        {
            return string.Format("<Compile Include=\"{0}.cs\" />", ClassName);
        }
    }
}