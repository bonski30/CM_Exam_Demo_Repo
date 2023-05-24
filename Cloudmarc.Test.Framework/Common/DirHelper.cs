namespace Cloudmarc.Test.Framework.Common
{
    public static class DirHelper
    {
        public static string GetSolutionRoot()
        {
            string root = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            return root;
        }

    }
}
