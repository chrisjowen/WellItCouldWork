﻿using System;
using System.Collections.Generic;
using ICSharpCode.NRefactory.Ast;

namespace WellItCouldWork.SyntaxHelpers
{
    public static class TypeExt
    {
        public static bool IsNodeOrNodeList(this Type type)
        {
            return (typeof (INode).IsAssignableFrom(type) || typeof (IEnumerable<INode>).IsAssignableFrom(type));
        }        
        
    }
}