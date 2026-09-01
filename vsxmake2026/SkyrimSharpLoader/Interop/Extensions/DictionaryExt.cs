using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyrimSharpLoader.Interop.Extensions
{
    public static class DictionaryExt
    {
        public static void Add<T, K>(this Dictionary<T, K> dict, KeyValuePair<T, K> value) where T : notnull
            => dict.Add(value.Key, value.Value);
    }
}
