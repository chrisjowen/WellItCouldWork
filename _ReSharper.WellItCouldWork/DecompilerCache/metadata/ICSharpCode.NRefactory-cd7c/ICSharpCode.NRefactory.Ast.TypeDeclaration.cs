// Type: ICSharpCode.NRefactory.Ast.TypeDeclaration
// Assembly: ICSharpCode.NRefactory, Version=0.0.0.0, Culture=neutral, PublicKeyToken=efe927acf176eea2
// Assembly location: C:\Code\WellItCouldWork\Libs\ICSharpCode.NRefactory.dll

using ICSharpCode.NRefactory;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.Ast
{
    public class TypeDeclaration : AttributedNode
    {
        public TypeDeclaration(Modifiers modifier, List<AttributeSection> attributes);
        public string Name { get; set; }
        public ClassType Type { get; set; }
        public List<TypeReference> BaseTypes { get; set; }
        public List<TemplateDefinition> Templates { get; set; }
        public Location BodyStartLocation { get; set; }
        public override object AcceptVisitor(IAstVisitor visitor, object data);
        public override string ToString();
    }
}
