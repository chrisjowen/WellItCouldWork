using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;

namespace WellItCouldWork.Investigation
{
    public static class NodeExt
    {
        public static bool HasChildren(this INode node)
        {
            return node.Children.Count > 0;
        }

        public static IEnumerable<T> OfType<T>(this IList<INode> nodes)
        {
            return nodes.Where(node => node is T).Cast<T>();
        }

        public static IEnumerable<INode> Flatten(this INode unit)
        {
            return new NodeFlattener(unit).Flatten();
        }
    }
}