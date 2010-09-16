using System.Collections.Generic;

namespace WellItCouldWork.Investigation
{
    public interface IProjectFile
    {
        string ProjectLocation { get; }
        string ProjectName { get; }
        List<Reference> References { get; }
        IList<Class> Classes { get; }
    }
}