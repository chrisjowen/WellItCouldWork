using System.Collections.Generic;

namespace WellItCouldWork.Investigation
{
    public interface IExamineClassFiles
    {
        IList<ClassInfo> Examine(string code);
    }
}