using System.Collections.Generic;

namespace WellItCouldWork.Investigation
{
    public interface IExamineClassFiles
    {
        IList<Reference> ExamineReferences(string code);
        IList<Class> ExamineClassDependencies(string code);
    }
}