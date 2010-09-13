// Type: ICSharpCode.NRefactory.Ast.AbstractNode
// Assembly: ICSharpCode.NRefactory, Version=0.0.0.0, Culture=neutral, PublicKeyToken=efe927acf176eea2
// Assembly location: C:\Code\WellItCouldWork\Libs\ICSharpCode.NRefactory.dll

using ICSharpCode.NRefactory;
using System.Collections;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.Ast
{
    public abstract class AbstractNode : INode
    {
        #region INode Members

        public abstract object AcceptVisitor(IAstVisitor visitor, object data);
        public virtual object AcceptChildren(IAstVisitor visitor, object data);
        public INode Parent { get; set; }
        public Location StartLocation { get; set; }
        public Location EndLocation { get; set; }
        public object UserData { get; set; }
        public List<INode> Children { get; set; }

        #endregion

        public virtual void AddChild(INode childNode);
        public static string GetCollectionString(ICollection collection);
    }
}
