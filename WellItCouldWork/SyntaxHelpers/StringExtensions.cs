﻿using System;

namespace WellItCouldWork.SyntaxHelpers
{
    public static class StringExtensions
    {
        public static String FormatMe(this String str, params object[] paramaters)
        {
            return string.Format(str, paramaters);
        }        
    }
}
