using System.Collections.Generic;
using WellItCouldWork.Parser;

namespace WellItCouldWork
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