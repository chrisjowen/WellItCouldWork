// Type: ICSharpCode.NRefactory.Ast.ObjectCreateExpression
// Assembly: ICSharpCode.NRefactory, Version=0.0.0.0, Culture=neutral, PublicKeyToken=efe927acf176eea2
// Assembly location: C:\Code\WellItCouldWork\Libs\ICSharpCode.NRefactory.dll

using ICSharpCode.NRefactory;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.Ast
{
    public class ObjectCreateExpression : Expression
    {
        public ObjectCreateExpression(TypeReference createType, List<Expression> parameters);
        public TypeReference CreateType { get; set; }
        public List<Expression> Parameters { get; set; }
        public CollectionInitializerExpression ObjectInitializer { get; set; }
        public bool IsAnonymousType { get; }
        public override object AcceptVisitor(IAstVisitor visitor, object data);
        public override string ToString();
    }
}
