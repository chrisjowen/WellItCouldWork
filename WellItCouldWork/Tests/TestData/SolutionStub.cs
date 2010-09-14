using System;
using System.Collections.Generic;
using WellItCouldWork.Investigation;

namespace WellItCouldWork.Tests.TestData
{
    public class SolutionStub : ISolution
    {
        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public string Path
        {
            get { throw new NotImplementedException(); }
        }

        public IList<IProject> Projects
        {
            get { throw new NotImplementedException(); }
        }

        public Class FindClassByExample(Class @class)
        {
            throw new NotImplementedException();
        }
    }
}
