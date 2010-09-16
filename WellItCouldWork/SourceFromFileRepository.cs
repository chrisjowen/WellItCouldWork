using System.IO;

namespace WellItCouldWork
{
    public class SourceFromFileRepository : IGetSourceCode
    {
        public string SourceFor(Class testClass)
        {
            return File.ReadAllText(testClass.FullPath);
        }
    }

    public interface IGetSourceCode
    {
        string SourceFor(Class testClass);
    }
}