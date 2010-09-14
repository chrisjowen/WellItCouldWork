using System.Collections.Generic;

namespace WellItCouldWork.Investigation
{
    public interface ISolution
    {
        string Name { get; }
        string Path { get; }
        IList<IProject> Projects { get; }
        Class FindClassByExample(Class @class);
    }
}