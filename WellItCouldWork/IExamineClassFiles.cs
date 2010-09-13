using System.Collections.Generic;

namespace WellItCouldWork
{
    public interface IExamineClassFiles
    {
        IList<ClassInfo> Examine(string code);
    }
}