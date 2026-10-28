using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyrimSharpLoader.Extensions
{
    public static class StringExt
    {
        public static string UpperFirst(this string s) => string.Concat(s[..1].ToUpper(), s[1..]);

        public static string LowerFirst(this string s) => string.Concat(s[..1].ToLower(), s[1..]);

        public static bool IsNullOrWhiteSpaceNotEmpty(this string value)
        {
            if (value == null)
                return true;

            if (value == "")
                return false;

            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsWhiteSpace(value[i])) return false;
            }

            return true;
        }
    }
}
