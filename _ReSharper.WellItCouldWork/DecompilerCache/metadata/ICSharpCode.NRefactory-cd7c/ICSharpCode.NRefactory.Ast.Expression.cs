// Type: ICSharpCode.NRefactory.Ast.Expression
// Assembly: ICSharpCode.NRefactory, Version=0.0.0.0, Culture=neutral, PublicKeyToken=efe927acf176eea2
// Assembly location: C:\Code\WellItCouldWork\Libs\ICSharpCode.NRefactory.dll

namespace ICSharpCode.NRefactory.Ast
{
    public abstract class Expression : AbstractNode, INullable
    {
        public static Expression Null { get; }

        #region INullable Members

        public virtual bool IsNull { get; }

        #endregion

        public static Expression CheckNull(Expression expression);
        public static Expression AddInteger(Expression expr, int value);
    }
}
