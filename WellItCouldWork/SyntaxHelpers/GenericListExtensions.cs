using System.Collections.Generic;

namespace WellItCouldWork.SyntaxHelpers
{
    public static class GenericListExtensions
    {
        public static bool IsEmpty<T>(this IList<T> list)
        {
            return list.Count == 0;
        }        
        
        public static bool IsNotEmpty<T>(this IList<T> list)
        {
            return !list.IsEmpty();
        }
    }
}