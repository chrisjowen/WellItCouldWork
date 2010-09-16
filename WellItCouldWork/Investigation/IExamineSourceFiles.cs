using System.Collections.Generic;

namespace WellItCouldWork.Investigation
{
    public interface IExamineSourceFiles
    {
        IList<TypeInfo> ExamineTypes(string code);
    }
}