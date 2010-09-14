using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ICSharpCode.NRefactory.Ast;
using WellItCouldWork.SyntaxHelpers;

namespace WellItCouldWork.Investigation
{
    internal class NodeFlattener
    {
        private readonly INode root;

        public NodeFlattener(INode root)
        {
            this.root = root;
        }

        public IList<INode> Flatten()
        {
            return GetNodeProperties(root);
        }

        private static IList<INode> GetNodeProperties(INode node)
        {
            var returnNodes = new List<INode>();
            var nodes = node.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(p => p.Name != "Parent" && p.PropertyType.IsNodeOrNodeList())
                .SelectMany(p => GetNodeValue(node, p));

            returnNodes.AddRange(nodes);

            if (nodes.Count() > 0)
                returnNodes.AddRange(nodes.SelectMany(GetNodeProperties));

            return returnNodes.ToList();
        }

        private static IEnumerable<INode> GetNodeValue(INode node, PropertyInfo propertyInfo)
        {
            var property = propertyInfo.GetValue(node, null);
            return property is INode ? new List<INode> { (INode)property } : property as IEnumerable<INode>;
        }
    }
}