using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyrimSharpLoader.Extensions
{
    public static class DictionaryExt
    {
        public static void Add<T, K>(this Dictionary<T, K> dict, KeyValuePair<T, K> pair) where T : notnull
        {
            dict.Add(pair.Key, pair.Value);
        }
    }
}
