namespace WellItCouldWork
{
    public class Reference
    {
        public Reference(string path)
        {
            this.path = path;
        }

        private string path;
        public string Path
        {
            get { return path.Contains(".dll") ? path : path + ".dll"; }
        }


    }
}