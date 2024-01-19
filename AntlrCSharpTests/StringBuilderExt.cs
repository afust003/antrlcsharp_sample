using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AntlrCSharpTests
{
    internal static class StringBuilderExt
    {
        public static StringBuilder AppendLineExt(this StringBuilder sb, string line)
        {
            sb.AppendLine(line);
            return sb;
        }
    }
}
