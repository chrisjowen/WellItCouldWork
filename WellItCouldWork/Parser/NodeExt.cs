using System;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;

namespace WellItCouldWork.Parser
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
            var flattened =  new NodeFlattener(unit).Flatten();
            return flattened;
        }
    }
    public static class TypeExt
    {
        public static bool IsNodeOrNodeList(this Type type)
        {
            return (typeof (INode).IsAssignableFrom(type) || typeof (IEnumerable<INode>).IsAssignableFrom(type));
        }
    }
}