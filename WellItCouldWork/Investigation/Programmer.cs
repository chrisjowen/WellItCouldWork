using System.Collections.Generic;

namespace WellItCouldWork.Investigation
{
    public class Programmer
    {
        private readonly IExamineClassFiles classExaminer;

        public Programmer() : this(new NRefactoryClassExaminer())
        {
        }

        internal Programmer(IExamineClassFiles classExaminer)
        {
            this.classExaminer = classExaminer;
        }

        public IList<ClassInfo> ExamineThisCode(string code)
        {
            return classExaminer.Examine(code);
        }
    }
}